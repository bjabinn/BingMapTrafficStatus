var BingMapKey = "AnqMOih8bvPT5If6bg0mEKTb-X4liSI8L0snaE4RqecU8X4tqv3Hb5LhQ79YU-4w";
var map;
function changeProvincia(province) {    
    $.ajax({
        type: "POST",
        url: "/Home/GetTrafficIncidences",
        data: {
            province: province
        },
        success: function (data) {
            addRequestPins(map, data.resourceSets[0].resources);
        },
        error: function (req, status, errorObj) {
            alert("error");
        }
    });
}

function GetMap() {
    map = new Microsoft.Maps.Map('#myMap', {
        center: new Microsoft.Maps.Location(37.340937, -6.062320),
        mapTypeId: Microsoft.Maps.MapTypeId.road,
        zoom: 11
    });
    //Add your post map load code here.
    changeProvincia("Seville");
}

//var renderRequestsMap = function (divIdForMap, requestData) {
//    if (requestData) {
//        var bingMap = createBingMap(divIdForMap);
//        addRequestPins(bingMap, requestData);
//    }
//}

function addRequestPins(bingMap, requestData) {
    var locations = [];
    $.each(requestData, function (index, data) {
        var location = new Microsoft.Maps.Location(data.toPoint.coordinates[0], data.toPoint.coordinates[1]);
        locations.push(location);
        var order = index + 1;
        var pin = new Microsoft.Maps.Pushpin(location, { title: data.description});
        bingMap.entities.push(pin);
    });
    var rect = Microsoft.Maps.LocationRect.fromLocations(locations);
    bingMap.setView({ bounds: rect, padding: 80 });
}

//function GetMap() {
//    renderRequestsMap("myMap", getLocationsFromModelRequests());
//};



//$(document).ready(function(){
//    createBingMap("myMap");
//});

//function getLocationsFromModelRequests() {
//    var requestData = [];
//    @foreach(var request in Model.Requests){
//        @:var reqData = { lat:@request.Latitude, long: @request.Longitude, name: '@request.Name', color:'blue'
//    };

//    if (request.Status == RequestStatus.Completed) {
//        @:reqData.color = 'green';
//    }

//    if (request.Status == RequestStatus.Canceled) {
//        @:reqData.color = 'red';
//    }

//    @:requestData.push(reqData);
//}
//return requestData;
//        }
