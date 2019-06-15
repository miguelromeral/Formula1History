// Where all the fun happens
function Initialize(lat, lng) {

            
    // Google has tweaked their interface somewhat - this tells the api to use that new UI
    google.maps.visualRefresh = true;
    var location = new google.maps.LatLng(lat, lng);

    // These are options that set initial zoom level, where the map is centered globally to start, and the type of map to show
    var mapOptions = {
        zoom: 15,
        center: location,
        mapTypeId: 'roadmap'
    };

    // This makes the div with id "map_canvas" a google map
    var map = new google.maps.Map(document.getElementById("map_canvas"), mapOptions);
            
    var marker = new google.maps.Marker({
        'position': new google.maps.LatLng(long, lat),
        'map': map,
        'title': item.PlaceName
    });

    // Make the marker-pin blue!
    marker.setIcon('http://maps.google.com/mapfiles/ms/icons/blue-dot.png');
    
            
            
}