import 'ol/ol.css';
import Map from 'ol/Map';
import View from 'ol/View';
import { Image as ImageLayer, Tile as TileLayer, Vector as VectorLayer } from 'ol/layer';
import ImageWMS from 'ol/source/ImageWMS';
import OSM from 'ol/source/OSM';
import Feature from 'ol/Feature';
import Geolocation from 'ol/Geolocation';
import Point from 'ol/geom/Point';
import { Vector as VectorSource } from 'ol/source';
import { Circle as CircleStyle, Fill, Stroke, Style } from 'ol/style';

import { defaults as defaultControls } from 'ol/control';
import MousePosition from 'ol/control/MousePosition';
import { createStringXY } from 'ol/coordinate';

import { get as getProjection } from 'ol/proj';
import { fromLonLat } from 'ol/proj';


const projection = getProjection('EPSG:7801');


var mousePositionControl = new MousePosition({
    coordinateFormat: createStringXY(4),
    projection: 'EPSG:7801',
    // comment the following two lines to have the mouse position
    // be placed within the map.
    className: 'custom-mouse-position',
    target: document.getElementById('mouse-position'),
    undefinedHTML: '&nbsp;'
});

var center = [23.3834, 42.3608];
const webCenter = fromLonLat(center);




var view = new View({
    center: webCenter,
    zoom: 15,
    projection: projection
});

var layers = [
    new TileLayer({
        source: new OSM()
    }),
    new ImageLayer({
        source: new ImageWMS({
            ratio: 1,
            url: 'http://localhost:8080/geoserver/PUP/wms',
            params: {
                'FORMAT': 'image/png',
                'VERSION': '1.1.0',
                "LAYERS": 'PUP:PUP'
            }
        })
    })
];

var map = new Map({
    controls: defaultControls().extend([mousePositionControl]),
    layers: layers,
    target: 'map',
    view: view
});




var geolocation = new Geolocation({
    // enableHighAccuracy must be set to true to have the heading value.
    trackingOptions: {
        enableHighAccuracy: true
    },
    projection: view.getProjection()
});

function el(id) {
    return document.getElementById(id);
}

el('track').addEventListener('change', function () {
    geolocation.setTracking(this.checked);
});

// update the HTML page when the position changes.
geolocation.on('change', function () {
    el('accuracy').innerText = geolocation.getAccuracy() + ' [m]';
    el('altitude').innerText = geolocation.getAltitude() + ' [m]';
    el('altitudeAccuracy').innerText = geolocation.getAltitudeAccuracy() + ' [m]';
    el('heading').innerText = geolocation.getHeading() + ' [rad]';
    el('speed').innerText = geolocation.getSpeed() + ' [m/s]';
});

// handle geolocation error.
geolocation.on('error', function (error) {
    var info = document.getElementById('info');
    info.innerHTML = error.message;
    info.style.display = '';
});

var accuracyFeature = new Feature();
geolocation.on('change:accuracyGeometry', function () {
    accuracyFeature.setGeometry(geolocation.getAccuracyGeometry());
});

var positionFeature = new Feature();
positionFeature.setStyle(new Style({
    image: new CircleStyle({
        radius: 6,
        fill: new Fill({
            color: '#3399CC'
        }),
        stroke: new Stroke({
            color: '#fff',
            width: 2
        })
    })
}));

geolocation.on('change:position', function () {
    var coordinates = geolocation.getPosition();
    positionFeature.setGeometry(coordinates ?
        new Point(coordinates) : null);
});

new VectorLayer({
    map: map,
    source: new VectorSource({
        features: [accuracyFeature, positionFeature]
    })
});




var projectionSelect = document.getElementById('projection');
projectionSelect.addEventListener('change', function (event) {
    mousePositionControl.setProjection(event.target.value);
});

var precisionInput = document.getElementById('precision');
precisionInput.addEventListener('change', function (event) {
    var format = createStringXY(event.target.valueAsNumber);
    mousePositionControl.setCoordinateFormat(format);
});




/* var untiled = new ol.layer.Image({
   source: new ol.source.ImageWMS({
     ratio: 1,
     url: 'http://localhost:8080/geoserver/PUP/wms',
     params: {'FORMAT': format,
              'VERSION': '1.1.1',
           "LAYERS": 'PUP:PUP',
           "exceptions": 'application/vnd.ogc.se_inimage',
     }
   })
 });

 var projection = new ol.proj.Projection({
     code: 'EPSG:7801',
     units: 'm',
     axisOrientation: 'neu',
     global: false
 });
*/
