using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Script.Services;
using System.Web.Services;

/// <summary>
/// Summary description for CourtWebService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
 [System.Web.Script.Services.ScriptService]
public class CourtWebService : System.Web.Services.WebService {

    public CourtWebService () {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    static DbDataContext context = new DbDataContext();

    [WebMethod]
    public void creat()
    {
        context.ObjectTrackingEnabled = false;
        context.DeferredLoadingEnabled = false;
        context.CreateDatabase();
    }

    #region " Users    "

    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]

    //===================================================



    // Get All Users
    [WebMethod]
    public void UserGetAllUsers()
    {
        context = new DbDataContext();

        context.DeferredLoadingEnabled = false;
        context.ObjectTrackingEnabled = false;

        List<User> LstUsers = new List<User>();

        var q = context.Users.ToList();
        q.ForEach(i =>
        {
            User u = new User()
            {
                Id = i.Id,
                UserName = i.UserName,
                UserPassword = i.UserPassword,
                Address = i.Address,
                Phone = i.Phone,
                Email = i.Email,
                Gender = i.Gender
            };

            LstUsers.Add(u);

        });
        JavaScriptSerializer js = new JavaScriptSerializer();

        Context.Response.Write(js.Serialize(LstUsers));
    }

    // Search By Id
    [WebMethod]
    public void GetSingleUser(int uid)
    {
        context = new DbDataContext();
        context.DeferredLoadingEnabled = false;
        context.ObjectTrackingEnabled = false;

        User q = context.Users.Single(c => c.Id == uid);

        var s = new JavaScriptSerializer().Serialize(q);

        Context.Response.Write(s);
    }



    // Save New User
    [WebMethod]
    public void UserSaveNewUser(User u)
    {

        DbDataContext context = new DbDataContext();
        context.Users.InsertOnSubmit(u);
        context.SubmitChanges();
    }





    // Edit Target User
    [WebMethod]
    public void EditUser(User u)
    {
        context = new DbDataContext();
        User q = context.Users.Single(c => c.Id == u.Id);
        q.UserName = u.UserName;
        // q.UserPassword = u.UserPassword;
        q.Address = u.Address;
        q.Phone = u.Phone;
        q.Email = u.Email;
        q.Gender = u.Gender;
        context.SubmitChanges();

    }



    // Delete Target User
    [WebMethod]
    public void DeleteUser(int i)
    {
        context = new DbDataContext();

        User q = context.Users.Single(c => c.Id == i);
        context.Users.DeleteOnSubmit(q);

        context.SubmitChanges();

    }




    #endregion

    #region "    Lawyers    المحامين  "

    #region "    All Lawyers Method             "

    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]

    // Get All Lawyers
    [WebMethod]
    public void UserGetAllLawyers()
    {
        context = new DbDataContext();

        context.DeferredLoadingEnabled = false;
        context.ObjectTrackingEnabled = false;

        List<Lawyer> LstLawyers = new List<Lawyer>();

        var q = context.Lawyers.ToList();
        q.ForEach(i =>
        {
            Lawyer l = new Lawyer()
            {
                Id = i.Id,
                LawyerName = i.LawyerName,
                Address = i.Address,
                Phone = i.Phone,
                Describe = i.Describe
            };

            LstLawyers.Add(l);

        });
        JavaScriptSerializer js = new JavaScriptSerializer();

        Context.Response.Write(js.Serialize(LstLawyers));
    }

    #endregion

    #region "   Save New Lawyer Method          "
    [WebMethod]
    public void LawyerSaveNewLawyer(Lawyer l)
    {

        DbDataContext context = new DbDataContext();

        context.Lawyers.InsertOnSubmit(l);
        context.SubmitChanges();


    }

    #endregion

    #region "     Get Single Lawyer    "


    [WebMethod]
    public void LawyerGetLawyer(int lid)
    {

        context = new DbDataContext();

        context.DeferredLoadingEnabled = false;
        context.ObjectTrackingEnabled = false;
        Lawyer l = context.Lawyers.Single(c => c.Id == lid);
        var s = new JavaScriptSerializer().Serialize(l);

        Context.Response.Write(s);
    }

    #endregion


    #region "    Update Lawyer Information      "
    [WebMethod]
    public int EditLawyer(string LawyerNam, string phn, string adrs, string des, int id)
    {
        try
        {
            int status = 0;
            using (DbDataContext context = new DbDataContext())
            {

                Lawyer obj = context.Lawyers.Single(c => c.Id == id);
                obj.LawyerName = LawyerNam;
                obj.Address = adrs;
                obj.Describe = des;
                obj.Phone = phn;


                context.SubmitChanges();
                status = obj.Id;
            }
            return status;
        }
        catch
        {
            return -1;
        }

    }

    #endregion

    #region "   Delete Lawyer Information       "

    [WebMethod]
    public void DeleteLowyer(int id)
    {
        using (DbDataContext context = new DbDataContext())
        {
            Lawyer obj = context.Lawyers.Single(c => c.Id == id);
            context.Lawyers.DeleteOnSubmit(obj);
            context.SubmitChanges();
        }
    }



    #endregion

    #endregion

    #region "     Clients    الموكلين  "

    #region "     All Clients     "

    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]


    // Get All Clients
    [WebMethod]
    public void ClientGetAllClients()
    {
        context = new DbDataContext();

        context.DeferredLoadingEnabled = false;
        context.ObjectTrackingEnabled = false;

        List<Client> LstClients = new List<Client>();

        var q = context.Clients.ToList();
        q.ForEach(i =>
        {
            Client c = new Client()
            {
                Id = i.Id,
                ClientName = i.ClientName,
                Described = i.Described,
                Email = i.Email,
                IdNumber = i.IdNumber,
                Address = i.Address,
                Phone = i.Phone,

            };

            LstClients.Add(c);

        });
        JavaScriptSerializer js = new JavaScriptSerializer();

        Context.Response.Write(js.Serialize(LstClients));
    }

    #endregion

    #region "   Save New Client Method          "

    [WebMethod]
    public void ClinentSaveNewClient(Client clnt)
    {

        using (DbDataContext context = new DbDataContext())
        {
            context.Clients.InsertOnSubmit(clnt);
            context.SubmitChanges();
        }


    }

    #endregion

    #region "  Edit         "
    [WebMethod]
    public int EditCleint(string Nam, string des, string idnum, string phn, string adrs, string eml, int id)
    {
        try
        {
            int status = 0;
            using (DbDataContext context = new DbDataContext())
            {

                Client obj = context.Clients.Single(c => c.Id == id);

                obj.ClientName = Nam;
                obj.Address = adrs;
                obj.Described = des;
                obj.Phone = phn;
                obj.Email = eml;
                obj.IdNumber = idnum;

                context.SubmitChanges();
                status = obj.Id;
            }
            return status;
        }
        catch
        {
            return -1;
        }

    }
    #endregion

    #region "  Delete      "

    [WebMethod]
    public void DeleteCleint(int cid)
    {
        using (DbDataContext context = new DbDataContext())
        {
            Client obj = context.Clients.Single(c => c.Id == cid);
            context.Clients.DeleteOnSubmit(obj);
            context.SubmitChanges();
        }
    }

    #endregion



    #endregion

    #region "  Opponents  الخصوم "

    #region "    All Opponents Method             "

    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    [WebMethod]

    public void GetAllOpponents()
    {
        context = new DbDataContext();

        context.DeferredLoadingEnabled = false;
        context.ObjectTrackingEnabled = false;

        List<Opponent> LstOpponents = new List<Opponent>();

        var q = context.Opponents.ToList();
        q.ForEach(i =>
        {
            Opponent c = new Opponent()
            {
                Id = i.Id,
                OpponentName = i.OpponentName,
                Described = i.Described,
                Email = i.Email,
                IdNumber = i.IdNumber,
                Address = i.Address,
                Phone = i.Phone,

            };

            LstOpponents.Add(c);

        });
        JavaScriptSerializer js = new JavaScriptSerializer();

        Context.Response.Write(js.Serialize(LstOpponents));
    }

    #endregion

    #region "   Save New Opponent Method          "

    [WebMethod]
    public void OpponentSaveNewOpponent(Opponent o)
    {
        context = new DbDataContext();
        context.Opponents.InsertOnSubmit(o);
        context.SubmitChanges();
    }

    #endregion

    #region " Get Opponent By Id"
    [WebMethod]
    public void OpponentGetSingleOpponent(int opid)
    {

        context = new DbDataContext();

        context.DeferredLoadingEnabled = false;
        context.ObjectTrackingEnabled = false;
        Opponent op = context.Opponents.Single(c => c.Id == opid);
        var s = new JavaScriptSerializer().Serialize(op);

        Context.Response.Write(s);
    }

    #endregion

    #region "  Edit         "
    [WebMethod]
    public int EditOpponent(string Nam, string des, string idnum, string phn, string adrs, string eml, int id)
    {
        try
        {
            int status = 0;
            using (DbDataContext context = new DbDataContext())
            {

                Opponent obj = context.Opponents.Single(c => c.Id == id);

                obj.OpponentName = Nam;
                obj.Address = adrs;
                obj.Described = des;
                obj.Phone = phn;
                obj.Email = eml;
                obj.IdNumber = idnum;

                context.SubmitChanges();
                status = obj.Id;
            }
            return status;
        }
        catch
        {
            return -1;
        }

    }
    #endregion

    #region "  Delete      "
    [WebMethod]
    public void DeleteOpponent(int id)
    {
        using (DbDataContext context = new DbDataContext())
        {
            Opponent obj = context.Opponents.Single(c => c.Id == id);
            context.Opponents.DeleteOnSubmit(obj);
            context.SubmitChanges();
        }
    }

    #endregion

    #endregion

    #region "   Employees   الموظفين"

    #region "    All Employees Method             "

    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    [WebMethod]

    public void EmployeesGetAllEmployees()
    {
        context = new DbDataContext();
        context.DeferredLoadingEnabled = false;
        context.ObjectTrackingEnabled = false;

        var q = context.Employees.ToList();
        var s = new JavaScriptSerializer().Serialize(q.ToList());

        Context.Response.Write(s);
    }

    #endregion

    #region "   Save New Employee Method          "

    [WebMethod]
    public void EmployeeSaveNewEmployee(Employee Emp)
    {
        try
        {


            using (DbDataContext context = new DbDataContext())
            {

                context.Employees.InsertOnSubmit(Emp);
                context.SubmitChanges();
            }


        }
        catch
        {

        }

    }

    #endregion

    #region "     Get Single Employee    "


    [WebMethod]
    public void EmployeeGetSingleEmployee(int Empid)
    {

        context = new DbDataContext();

        context.DeferredLoadingEnabled = false;
        context.ObjectTrackingEnabled = false;
        Employee emp = context.Employees.Single(c => c.Id == Empid);
        var s = new JavaScriptSerializer().Serialize(emp);

        Context.Response.Write(s);
    }

    #endregion

    #region "  Edit         "
    [WebMethod]
    public int EditEmployee(string Nam, string des, string idnum, string phn, string adrs, string eml, int id)
    {
        try
        {
            int status = 0;
            using (DbDataContext context = new DbDataContext())
            {

                Employee obj = context.Employees.Single(c => c.Id == id);

                obj.EmployeeName = Nam;
                obj.Address = adrs;
                obj.Described = des;
                obj.Phone = phn;
                obj.Email = eml;
                obj.IdNumber = idnum;

                context.SubmitChanges();
                status = obj.Id;
            }
            return status;
        }
        catch
        {
            return -1;
        }

    }
    #endregion

    #region "  Delete      "

    [WebMethod]
    public void DeleteEmployee(int id)
    {
        using (DbDataContext context = new DbDataContext())
        {
            Employee obj = context.Employees.Single(c => c.Id == id);
            context.Employees.DeleteOnSubmit(obj);
            context.SubmitChanges();
        }
    }

    #endregion

    #endregion

    #region "     FollowUpIssues    متابعه القضايا  "

    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]

    [WebMethod]
    public void GetFollowUpByIssueId(int xid)
    {
        context = new DbDataContext();
        context.DeferredLoadingEnabled = false;
        context.ObjectTrackingEnabled = false;

        var q = context.FollowUpIssues.Where(c => c.IssueID == xid).Select(c => c).ToList();
        List<FollowUpIssue> Lst = new List<FollowUpIssue>();


        q.ForEach(i =>
        {
            FollowUpIssue f = new FollowUpIssue()
            {
                Id = i.Id,
                IssueID = i.IssueID,
                ClientId = i.ClientId,
                LawyerId = i.LawyerId,
                OpponentId = i.OpponentId

            };

            Lst.Add(f);

        });
        JavaScriptSerializer js = new JavaScriptSerializer();

        Context.Response.Write(js.Serialize(Lst));
    }

    [WebMethod]
    public void FollowUpIssueSaveNewFollowUpIssue(FollowUpIssue f)
    {
        context = new DbDataContext();
        context.FollowUpIssues.InsertOnSubmit(f);
        context.SubmitChanges();
    }


    [WebMethod]
    public int EditNewFollowUpIssue(int issueid, int lawerid, int clintid, int oppondid, int xid)
    {
        try
        {
            int status = 0;
            using (DbDataContext context = new DbDataContext())
            {

                FollowUpIssue obj = context.FollowUpIssues.Single(c => c.Id == xid);

                obj.IssueID = issueid;
                obj.LawyerId = lawerid;
                obj.ClientId = clintid;
                obj.OpponentId = oppondid;


                context.SubmitChanges();
                status = obj.Id;
            }
            return status;
        }
        catch
        {
            return -1;
        }
    }

    [WebMethod]
    public void DeleteFollowUpIssue(int xid)
    {
        using (DbDataContext context = new DbDataContext())
        {
            FollowUpIssue obj = context.FollowUpIssues.Single(c => c.Id == xid);
            context.FollowUpIssues.DeleteOnSubmit(obj);
            context.SubmitChanges();
        }
    }


    #endregion

    #region " Issue Levels    مستويات القضية"


    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    [WebMethod]

    public void IssueLevelsByFollowUpIssue(int xFollowUpId)
    {
        context = new DbDataContext();
        context.DeferredLoadingEnabled = false;
        context.ObjectTrackingEnabled = false;

        var q = context.IssueLevels.Where(c => c.FollowUpIssueId == xFollowUpId).Select(c => c).ToList();
        var s = new JavaScriptSerializer().Serialize(q.ToList());

        Context.Response.Write(s);
    }

    [WebMethod]
    public int SaveNewLevel(string levelnam, double totalcost, double payment, double remain, DateTime date, int empid, string xstatus, int folowid)
    {
        try
        {
            int status = 0;
            using (DbDataContext context = new DbDataContext())
            {

                IssueLevel obj = new IssueLevel()
                {
                    LevelName = levelnam,
                    TotalCost = totalcost,
                    Payment = payment,
                    Remain = remain,
                    TheDate = DateTime.Now,
                    EmployeeId = empid,
                    Status = xstatus,
                    FollowUpIssueId = folowid
                };

                context.IssueLevels.InsertOnSubmit(obj);
                context.SubmitChanges();
                status = obj.Id;
            }
            return status;
        }
        catch
        {
            return -1;
        }
    }


    #endregion

    #region "    Issues  القضايا      "

    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    [WebMethod]

    public void GetAllIssues()
    {
        context = new DbDataContext();

        context.DeferredLoadingEnabled = false;
        context.ObjectTrackingEnabled = false;

        List<Issue> LstIssues = new List<Issue>();

        var q = context.Issues.ToList();
        q.ForEach(i =>
        {
            Issue c = new Issue()
            {
                Id = i.Id,
                MainNumber = i.MainNumber,
                NumberAtCourt = i.NumberAtCourt,
                NumberAtCourtComputer = i.NumberAtCourtComputer,
                ProsecutorName = i.ProsecutorName,
                CenterName = i.CenterName,
                TheDate = i.TheDate


            };

            LstIssues.Add(c);

        });
        JavaScriptSerializer js = new JavaScriptSerializer();

        Context.Response.Write(js.Serialize(LstIssues));
    }


    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    [WebMethod]

    public void GetIssueById(int xid)
    {
        context = new DbDataContext();
        context.DeferredLoadingEnabled = false;
        context.ObjectTrackingEnabled = false;

        var q = context.Issues.Where(c => c.Id == xid).Select(c => c).Single();
        var s = new JavaScriptSerializer().Serialize(q).Single();

        Context.Response.Write(s);
    }


    [WebMethod]
    public void IssueSaveNewIssue(Issue issue)
    {
        using (DbDataContext context = new DbDataContext())
        {

            context.Issues.InsertOnSubmit(issue);
            context.SubmitChanges();
        }
    }


    #endregion

    #region "   Court Hearing جلسات المحكمة   و الاستماع في القضبة       "

    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    [WebMethod]

    public void GetHearingByIssueById(int issueid)
    {
        context = new DbDataContext();
        context.DeferredLoadingEnabled = false;
        context.ObjectTrackingEnabled = false;

        var q = context.Courthearings.Where(c => c.IssueId == issueid).Select(c => c).ToList();
        var s = new JavaScriptSerializer().Serialize(q.ToList());

        Context.Response.Write(s);
    }

    [WebMethod]
    public void SaveNewHearing(Courthearing h)
    {
        context = new DbDataContext();
        context.Courthearings.InsertOnSubmit(h);
        context.SubmitChanges();


    }



    [WebMethod]
    public int EditHearing(int issueid, DateTime startat, DateTime finishat, string commt, string stats, int id)
    {
        try
        {
            int status = 0;
            using (DbDataContext context = new DbDataContext())
            {
                Courthearing obj = context.Courthearings.Where(c => c.Id == id).Single();

                obj.IssueId = issueid;
                obj.StartAt = startat;
                obj.FinishAt = finishat;
                obj.Comment = commt;
                obj.Status = stats;

                context.SubmitChanges();
                status = obj.Id;
            }
            return status;
        }
        catch (Exception)
        {

            return -1;
        }
    }


    #endregion

    #region "   InBox  "


    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    [WebMethod]

    public void GetAllInBox()
    {
        context = new DbDataContext();
        context.DeferredLoadingEnabled = false;
        context.ObjectTrackingEnabled = false;

        var q = context.InBoxes.ToList();
        var s = new JavaScriptSerializer().Serialize(q.ToList());

        Context.Response.Write(s);
    }
    [WebMethod]
    public int SendMessage(string subject, int senderid, int recevedid, string Msgtext, DateTime date, string xstatus)
    {
        try
        {
            int status = 0;
            using (DbDataContext context = new DbDataContext())
            {
                OutBox obj = new OutBox()
                {
                    Subject = subject,
                    SenderId = senderid,
                    ReciverId = recevedid,
                    MessageText = Msgtext,
                    DateofMessage = date,
                    Status = xstatus
                };
                context.OutBoxes.InsertOnSubmit(obj);
                context.SubmitChanges();
                status = obj.Id;
            }
            return status;
        }
        catch (Exception)
        {

            return -1;
        }
    }
    [WebMethod]
    public int SetAsReadedMessage(int messgeid)
    {
        try
        {
            int status = 0;
            using (DbDataContext context = new DbDataContext())
            {
                InBox obj = context.InBoxes.Where(c => c.Id == messgeid && c.Status == "UnReaded").Single();

                obj.Status = "Readed";


                context.SubmitChanges();
                status = obj.Id;
            }
            return status;
        }
        catch (Exception)
        {

            return -1;
        }
    }

    #endregion
}
