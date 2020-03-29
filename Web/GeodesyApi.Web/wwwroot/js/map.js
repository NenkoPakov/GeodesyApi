﻿
<head>
    <meta charset="utf-8" />
    <meta
        name="viewport"
        content="width=device-width,initial-scale=1,maximum-scale=1,user-scalable=no"
    />
    <title>Calcite Maps and Bootstrap - 4.14</title>

    <!-- Calcite Bootstrap -->
    <link
        rel="stylesheet"
        href="https://esri.github.io/calcite-maps/dist/css/calcite-maps-bootstrap.min-v0.8.css"
    />

    <!-- Calcite Maps -->
    <link
        rel="stylesheet"
        href="https://esri.github.io/calcite-maps/dist/css/calcite-maps-arcgis-4.x.min-v0.8.css"
    />

    <!-- ArcGIS JS 4 -->
    <link
        rel="stylesheet"
        href="https://js.arcgis.com/4.14/esri/themes/light/main.css"
    />

    <style>
        html,
      body {
            margin: 0;
    padding: 0;
    height: 100%;
  }
    </style>
</head>

    <body class="calcite-maps calcite-nav-top">
        <!-- Navbar -->
   
    <nav
            class="navbar calcite-navbar navbar-fixed-top calcite-text-light calcite-bg-dark"
        >
            <!-- Menu -->
      <div
                class="dropdown calcite-dropdown calcite-text-dark calcite-bg-light"
                role="presentation"
            >
                <a
                    class="dropdown-toggle"
                    role="button"
                    aria-haspopup="true"
                    aria-expanded="false"
                >
                    <div class="calcite-dropdown-toggle">
                        <span class="sr-only">Toggle dropdown menu</span> <span></span>
                        <span></span> <span></span> <span></span>
                    </div>
                </a>
                <ul class="dropdown-menu">
                    <li class="active">
                        <a
                            class="hidden-md hidden-lg"
                            href="#mapTab"
                            aria-controls="mapTab"
                            role="tab"
                            data-toggle="tab"
                        >
                            Map</a
                        >
                    </li>
                    <li>
                        <a
                            class="hidden-md hidden-lg"
                            href="#sceneTab"
                            aria-controls="sceneTab"
                            role="tab"
                            data-toggle="tab"
                        >
                            Scene</a
                        >
                    </li>
                    <li>
                        <a role="button" data-target="#panelBasemaps" aria-haspopup="true"
                        ><span class="glyphicon glyphicon-th-large"></span> Basemaps</a
                        >
                    </li>
                    <li>
                        <a role="button" data-target="#panelSettings" aria-haspopup="true"
                        ><span class="glyphicon glyphicon-cog"></span> Settings</a
                        >
                    </li>
                    <li>
                        <a role="button" id="calciteToggleNavbar" aria-haspopup="true"
                        ><span class="glyphicon glyphicon-fullscreen"></span> Full Map</a
                        >
                    </li>
                </ul>
            </div>
            <!-- Title -->
      <div class="calcite-title calcite-overflow-hidden">
                <span class="calcite-title-main">Calcite Maps</span>
                <span class="calcite-title-divider hidden-xs"></span>
                <span class="calcite-title-sub hidden-xs"
                >A modern framework for building map apps</span
                >
            </div>
            <!-- Nav -->
      <ul class="nav navbar-nav calcite-nav">
                <li class="active">
                    <a
                        id="mapNav"
                        class="hidden-xs hidden-sm"
                        href="#mapTab"
                        aria-controls="mapTab"
                        aria-expanded="true"
                        role="tab"
                        data-toggle="tab"
                        data-tooltip="tip"
                        title="2D View"
                        data-placement="bottom"
                    >Map</a
                    >
                </li>
                <li>
                    <a
                        id="sceneNav"
                        class="hidden-xs hidden-sm"
                        href="#sceneTab"
                        aria-controls="sceneTab"
                        role="tab"
                        data-toggle="tab"
                        data-tooltip="tip"
                        title="3D View"
                        data-placement="bottom"
                    >Scene</a
                    >
                </li>
                <li>
                    <div class="calcite-navbar-search calcite-search-expander">
                        <div id="searchWidgetDiv"></div>
                    </div>
                </li>
            </ul>
        </nav>
        <!--/.calcite-navbar -->
   
    <!-- Map  -->
               
    <div class="calcite-map calcite-map-absolute">
            <div id="tabContainer" class="tab-content">
                <div id="mapTab" class="tab-pane fade in active" role="tabpanel">
                    <div id="mapViewDiv"></div>
                </div>
                <div id="sceneTab" class="tab-pane fade" role="tabpanel">
                    <div id="sceneViewDiv"></div>
                </div>
            </div>
        </div>
        <!-- /.calcite-map -->
   
    <!-- Panels -->
               
    <div
            class="calcite-panels calcite-panels-right calcite-text-light calcite-bg-dark panel-group"
        >
            <!-- Basemaps Panel -->
     
      <div id="panelBasemaps" class="panel collapse">
                <div id="headingBasemaps" class="panel-heading" role="tab">
                    <div class="panel-title">
                        <a
                            class="panel-toggle collapsed"
                            role="button"
                            data-toggle="collapse"
                            href="#collapseBasemaps"
                            aria-expanded="false"
                            aria-controls="collapseBasemaps"
                        ><span
                            class="glyphicon glyphicon-th-large"
                            aria-hidden="true"
                        ></span
                            ><span class="panel-label">Basemaps</span></a
                        >
                        <a
                            class="panel-close"
                            role="button"
                            data-toggle="collapse"
                            data-target="#panelBasemaps"
                        ><span class="esri-icon esri-icon-close" aria-hidden="true"></span
                        ></a>
                    </div>
                </div>
                <div
                    id="collapseBasemaps"
                    class="panel-collapse collapse"
                    role="tabpanel"
                    aria-labelledby="headingBasemaps"
                >
                    <div class="panel-body"><div id="basemapPanelDiv"></div></div>
                </div>
            </div>

            <!-- Panel Settings -->
     
      <div id="panelSettings" class="panel panel-map collapse">
                <div id="headingSettings" class="panel-heading">
                    <div class="panel-title">
                        <a
                            class="panel-toggle"
                            role="button"
                            data-toggle="collapse"
                            href="#collapseSettings"
                            data-parent="#panelAccordion"
                            aria-expanded="true"
                            aria-controls="collapseSettings"
                        ><span class="glyphicon glyphicon-cog" aria-hidden="true"></span
                        ><span class="panel-label">Settings</span></a
                        >
                        <a
                            class="panel-close"
                            role="button"
                            data-toggle="collapse"
                            data-target="#panelSettings"
                        ><span class="esri-icon esri-icon-close" aria-hidden="true"></span
                        ></a>
                    </div>
                </div>
                <div
                    id="collapseSettings"
                    class="panel-collapse collapse"
                    role="tabpanel"
                    aria-labelledby="headingSettings"
                >
                    <div class="panel-body">
                        <div class="form-horizontal">
                            <!-- Theme -->
             
              <div class="form-group">
                                <label for="settingsTheme" class="col-xs-3 control-label"
                                >Theme</label
                                >
                                <div class="col-xs-9">
                                    <select id="settingsTheme" class="form-control">
                                        <option
                                            value="calcite-dark"
                                            data-textcolor="calcite-text-light"
                                            data-bgcolor="calcite-bg-dark"
                                            selected
                                        >Calcite Dark</option
                                        >
                                        <option
                                            value="calcite-light"
                                            data-textcolor="calcite-text-dark"
                                            data-bgcolor="calcite-bg-light"
                                        >Calcte Light</option
                                        >
                                    </select>
                                </div>
                            </div>

                            <!-- Color -->
             
              <div class="form-group">
                                <label for="settingsColor" class="col-xs-3 control-label"
                                >Color</label
                                >
                                <div class="col-xs-9">
                                    <select id="settingsColor" class="form-control">
                                        <option value="" data-theme="calcite-theme-light"
                                        >Calcite Default</option
                                        >
                                        <option
                                            value="calcite-bgcolor-dark-blue"
                                            data-textcolor="calcite-text-light"
                                            data-bgcolor="calcite-bg-custom"
                                        >Calcite Dark Blue</option
                                        >
                                        <option
                                            value="calcite-bgcolor-dark-green"
                                            data-textcolor="calcite-text-light"
                                            data-bgcolor="calcite-bg-custom"
                                        >Calcite Dark Green</option
                                        >
                                        <option
                                            value="calcite-bgcolor-dark-brown"
                                            data-textcolor="calcite-text-light"
                                            data-bgcolor="calcite-bg-custom"
                                        >Calcite Dark Brown
                    </option>
                                        <option
                                            value="calcite-bgcolor-dark-red"
                                            data-textcolor="calcite-text-light"
                                            data-bgcolor="calcite-bg-custom"
                                        >Calcite Dark Red</option
                                        >
                                        <option
                                            value="calcite-bgcolor-darkest-grey"
                                            data-textcolor="calcite-text-light"
                                            data-bgcolor="calcite-bg-custom"
                                        >Calcite Darkest Grey</option
                                        >
                                        <option
                                            value="calcite-bgcolor-lightest-grey"
                                            data-textcolor="calcite-text-dark"
                                            data-bgcolor="calcite-bg-custom"
                                        >Calcite Lightest Grey</option
                                        >
                                        <option
                                            value="calcite-bgcolor-blue-75"
                                            data-textcolor="calcite-text-light"
                                            data-bgcolor="calcite-bg-custom"
                                        >Calcite Blue 75%</option
                                        >
                                        <option
                                            value="calcite-bgcolor-black-75"
                                            data-textcolor="calcite-text-light"
                                            data-bgcolor="calcite-bg-custom"
                                        >Calcite Black 75%</option
                                        >
                                    </select>
                                </div>
                            </div>

                            <!-- Widgets -->
             
              <div class="form-group">
                                <label for="settingsWidgets" class="col-xs-3 control-label"
                                >Widgets</label
                                >
                                <div class="col-xs-9">
                                    <select id="settingsWidgets" class="form-control">
                                        <option value="calcite-widgets-dark">Calcite Dark</option>
                                        <option value="calcite-widgets-light" selected
                                        >Calcite Light</option
                                        >
                                    </select>
                                </div>
                            </div>

                            <!-- Layout -->
             
              <div class="form-group">
                                <label for="settingsLayout" class="col-xs-3 control-label"
                                >Layout</label
                                >
                                <div class="col-xs-9">
                                    <select id="settingsLayout" class="form-control">
                                        <option
                                            value="calcite-nav-top"
                                            data-nav="navbar-fixed-top"
                                            selected
                                        >Top</option
                                        >
                                        <option
                                            value="calcite-nav-bottom"
                                            data-nav="navbar-fixed-bottom"
                                        >Bottom</option
                                        >
                                    </select>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <!-- /.calcite-panels -->
   
    <script type="text/javascript">
            var dojoConfig = {
                packages: [
          {
                name: "bootstrap",
        location:
          "https://esri.github.io/calcite-maps/dist/vendor/dojo-bootstrap"
      },
          {
                name: "calcite-maps",
        location: "https://esri.github.io/calcite-maps/dist/js/dojo"
      }
    ]
  };
    </script>

        <!-- ArcGIS JS 4 -->
    <script src="https://js.arcgis.com/4.14/"></script>

        <script>
            var app;
     
            require([
              "esri/Map",
              "esri/views/MapView",
              "esri/views/SceneView",
              "esri/widgets/Search",
              "esri/widgets/BasemapGallery",
              "esri/core/watchUtils",
              // Calcite Maps
              "calcite-maps/calcitemaps-v0.8",
     
              // Calcite Maps ArcGIS Support
              "calcite-maps/calcitemaps-arcgis-support-v0.8",
     
              // Bootstrap
              "bootstrap/Collapse",
              "bootstrap/Dropdown",
              "bootstrap/Tab",
              // Can use @dojo shim for Array.from for IE11
              "@dojo/framework/shim/array"
            ], function(
              Map,
              MapView,
              SceneView,
              Search,
              Basemaps,
              watchUtils,
              CalciteMaps,
              CalciteMapsArcGIS
      ) {
                /******************************************************************
                 *
                 * App settings
                 *
                 ******************************************************************/

                app = {
                    center: [-40, 40],
                    scale: 50000000,
                    basemap: "streets",
                    viewPadding: {
                        top: 50,
                        bottom: 0
                    },
                    uiComponents: ["zoom", "compass", "attribution"],
                    mapView: null,
                    sceneView: null,
                    containerMap: "mapViewDiv",
                    containerScene: "sceneViewDiv",
                    activeView: null,
                    searchWidget: null
                };

        /******************************************************************
         *
         * Create the map and scene view and ui components
         *
         ******************************************************************/

        // Map
        const map = new Map({
                basemap: app.basemap
      });

      // 2D view
        app.mapView = new MapView({
                container: app.containerMap,
        map: map,
        center: app.center,
        scale: app.scale,
        padding: app.viewPadding,
          ui: {
                components: app.uiComponents
      }
    });

    CalciteMapsArcGIS.setPopupPanelSync(app.mapView);

    // 3D view
        app.sceneView = new SceneView({
                container: app.containerScene,
        map: map,
        center: app.center,
        scale: app.scale,
        padding: app.viewPadding,
          ui: {
                components: app.uiComponents
      }
    });

    CalciteMapsArcGIS.setPopupPanelSync(app.sceneView);

    // Set the active view to scene
    setActiveView(app.mapView);

    // Create the search widget and add it to the navbar instead of view
    app.searchWidget = new Search(
          {
                view: app.activeView
      },
      "searchWidgetDiv"
    );

    CalciteMapsArcGIS.setSearchExpandEvents(app.searchWidget);

    // Create basemap widget
        app.basemapWidget = new Basemaps({
                view: app.activeView,
        container: "basemapPanelDiv"
      });

      /******************************************************************
       *
       * Synchronize the view, search and popup
       *
       ******************************************************************/

      // Views
        function setActiveView(view) {
                app.activeView = view;
      }

        function syncViews(fromView, toView) {
          const viewPt = fromView.viewpoint.clone();
                      fromView.container = null;
          if (fromView.type === "3d") {
                toView.container = app.containerMap;
          } else {
                toView.container = app.containerScene;
      }
      toView.padding = app.viewPadding;
      toView.viewpoint = viewPt;
    }

    // Search Widget
        function syncSearch(view) {
                watchUtils.whenTrueOnce(view, "ready", function () {
                    app.searchWidget.view = view;
                    if (app.searchWidget.selectedResult) {
                        app.searchWidget.search(app.searchWidget.selectedResult.name);
                    }
                });
      }

      // Tab - toggle between map and scene view
      const tabs = Array.from(
        document.querySelectorAll(".calcite-navbar li a[data-toggle='tab']")
      );
        tabs.forEach(function(tab) {
                tab.addEventListener("click", function (event) {
                    if (event.target.text.indexOf("Map") > -1) {
                        syncViews(app.sceneView, app.mapView);
                        setActiveView(app.mapView);
                    } else {
                        syncViews(app.mapView, app.sceneView);
                        setActiveView(app.sceneView);
                    }
                    syncSearch(app.activeView);
                });
      });

      /******************************************************************
       *
       * Apply Calcite Maps CSS classes to change application on the fly
       *
       * For more information about the CSS styles or Sass build visit:
       * http://github.com/esri/calcite-maps
       *
       ******************************************************************/

      const cssSelectorUi = [
        document.querySelector(".calcite-navbar"),
        document.querySelector(".calcite-panels")
      ];
      const cssSelectorMap = document.querySelector(".calcite-map");

      // Theme - light (default) or dark theme
      const settingsTheme = document.getElementById("settingsTheme");
      const settingsColor = document.getElementById("settingsColor");
        settingsTheme.addEventListener("change", function(event) {
          const textColor =
                        event.target.options[event.target.selectedIndex].dataset.textcolor;
                      const bgColor =
                        event.target.options[event.target.selectedIndex].dataset.bgcolor;
           
          cssSelectorUi.forEach(function(element) {
                element.classList.remove(
                    "calcite-text-dark",
                    "calcite-text-light",
                    "calcite-bg-dark",
                    "calcite-bg-light",
                    "calcite-bg-custom"
                );
        element.classList.add(textColor, bgColor);
        element.classList.remove(
          "calcite-bgcolor-dark-blue",
          "calcite-bgcolor-blue-75",
          "calcite-bgcolor-dark-green",
          "calcite-bgcolor-dark-brown",
          "calcite-bgcolor-darkest-grey",
          "calcite-bgcolor-lightest-grey",
          "calcite-bgcolor-black-75",
          "calcite-bgcolor-dark-red"
        );
        element.classList.add(bgColor);
      });
      settingsColor.value = "";
    });

    //Color - custom color
        settingsColor.addEventListener("change", function(event) {
          const customColor = event.target.value;
                      const textColor =
                        event.target.options[event.target.selectedIndex].dataset.textcolor;
                      const bgColor =
                        event.target.options[event.target.selectedIndex].dataset.bgcolor;
           
          cssSelectorUi.forEach(function(element) {
                element.classList.remove(
                    "calcite-text-dark",
                    "calcite-text-light",
                    "calcite-bg-dark",
                    "calcite-bg-light",
                    "calcite-bg-custom"
                );
        element.classList.add(textColor, bgColor);
        element.classList.remove(
          "calcite-bgcolor-dark-blue",
          "calcite-bgcolor-blue-75",
          "calcite-bgcolor-dark-green",
          "calcite-bgcolor-dark-brown",
          "calcite-bgcolor-darkest-grey",
          "calcite-bgcolor-lightest-grey",
          "calcite-bgcolor-black-75",
          "calcite-bgcolor-dark-red"
        );
        element.classList.add(customColor);
            if (!customColor) {
                settingsTheme.dispatchEvent(new Event("change"));
      }
    });
  });

  // Widgets - light (default) or dark theme
  const settingsWidgets = document.getElementById("settingsWidgets");
        settingsWidgets.addEventListener("change", function(event) {
          const theme = event.target.value;
                      cssSelectorMap.classList.remove(
                        "calcite-widgets-dark",
                        "calcite-widgets-light"
                      );
                      cssSelectorMap.classList.add(theme);
                    });
           
                    // Layout - top or bottom nav position
                    const settingsLayout = document.getElementById("settingsLayout");
        settingsLayout.addEventListener("change", function(event) {
          const layout = event.target.value;
                      const layoutNav =
                        event.target.options[event.target.selectedIndex].dataset.nav;
           
                      document.body.classList.remove(
                        "calcite-nav-bottom",
                        "calcite-nav-top"
                      );
                      document.body.classList.add(layout);
           
                      const nav = document.querySelector("nav");
                      nav.classList.remove("navbar-fixed-bottom", "navbar-fixed-top");
                      nav.classList.add(layoutNav);
                      setViewPadding(layout);
                    });
           
                    // Set view padding for widgets based on navbar position
        function setViewPadding(layout) {
                let padding, uiPadding;
        // Top
          if (layout === "calcite-nav-top") {
                padding = {
                    padding: {
                        top: 50,
                        bottom: 0
                    }
                };
            uiPadding = {
                padding: {
                top: 15,
        right: 15,
        bottom: 30,
        left: 15
      }
    };
          } else {
                // Bottom
                padding = {
                    padding: {
                        top: 0,
                        bottom: 50
                    }
                };
            uiPadding = {
                padding: {
                top: 30,
        right: 15,
        bottom: 15,
        left: 15
      }
    };
  }
  app.mapView.set(padding);
  app.mapView.ui.set(uiPadding);
  app.sceneView.set(padding);
  app.sceneView.ui.set(uiPadding);
  // Reset popup
  if (
    app.activeView.popup.visible &&
    app.activeView.popup.dockEnabled
          ) {
                app.activeView.popup.visible = false;
        app.activeView.popup.visible = true;
      }
    }
  });
    </script>
    </body>
