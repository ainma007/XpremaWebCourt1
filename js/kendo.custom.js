// Kendo UI theme for data visualization widgets
// Use as theme: 'newTheme' in configuration options (or change the name)
kendo.dataviz.ui.registerTheme('newTheme', {
    "chart": {
        "title": {
            "color": "#8e8e8e"
        },
        "legend": {
            "labels": {
                "color": "#232323"
            }
        },
        "chartArea": {},
        "seriesDefaults": {
            "labels": {
                "color": "#000"
            }
        },
        "axisDefaults": {
            "line": {
                "color": "#8e8e8e"
            },
            "labels": {
                "color": "#232323"
            },
            "minorGridLines": {
                "color": "#f0f0f0"
            },
            "majorGridLines": {
                "color": "#dfdfdf"
            },
            "title": {
                "color": "#232323"
            }
        },
        "seriesColors": [
            "#ff6800",
            "#a0a700",
            "#ff8d00",
            "#678900",
            "#ffb53c",
            "#396000"
        ],
        "tooltip": {}
    },
    "gauge": {
        "pointer": {
            "color": "#ea7001"
        },
        "scale": {
            "rangePlaceholderColor": "#dedede",
            "labels": {
                "color": "#2e2e2e"
            },
            "minorTicks": {
                "color": "#2e2e2e"
            },
            "majorTicks": {
                "color": "#2e2e2e"
            },
            "line": {
                "color": "#2e2e2e"
            }
        }
    }
});