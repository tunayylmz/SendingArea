
$(function () {
    google.maps.event.addDomListener(window, 'load', function () {
        var options = {
            componentRestrictions: { country: 'tr' }
        };
        var from_places = new google.maps.places.Autocomplete(document.getElementById('from_places'), options);
        var to_places = new google.maps.places.Autocomplete(document.getElementById('to_places'), options);

        google.maps.event.addListener(from_places, 'place_changed', function () {
            var from_place = from_places.getPlace();
            var from_address = from_place.formatted_address;
            $('#origin').val(from_address);
        });

        google.maps.event.addListener(to_places, 'place_changed', function () {
            var to_place = to_places.getPlace();
            var to_address = to_place.formatted_address;
            $('#destination').val(to_address);
            calculateDistance();
            KmHesabi('Km');
        });
    });

    function calculateDistance() {
        var origin = $('#origin').val();
        var destination = $('#destination').val();
        var service = new google.maps.DistanceMatrixService();
        service.getDistanceMatrix(
            {
                origins: [origin],
                destinations: [destination],
                travelMode: google.maps.TravelMode.DRIVING,
                unitSystem: google.maps.UnitSystem.IMPERIAL,
                avoidHighways: false,
                avoidTolls: false,
            }, callback);
    }
    function callback(response, status) {
        if (status != google.maps.DistanceMatrixStatus.OK) {
            $('#result').html(err);
        } else {
            var origin = response.originAddresses[0];
            var destination = response.destinationAddresses[0];
            console.log(response.rows[0].elements[0].status);
            if (response.rows[0].elements[0].status === "ZERO_RESULTS") {
                $('#result').html("Better get on a plane. There are no roads between" + origin + " and "+ destination);

            } else {
                console.clear();
                console.log(response.rows[0].elements[0].distance);
                var distance = response.rows[0].elements[0].distance;
                var duration = response.rows[0].elements[0].duration;
                
                var distance_in_kilo = distance.value / 1000;
                var distance_in_mile = distance.value / 1609.34;
                var duration_text = duration.text;
                var duration_value = duration.value;
                $('#in_mile').text(distance_in_mile.toFixed(2));
                $('#in_kilo').text(distance_in_kilo.toFixed(2));
                $('#duration_text').text(duration_text);
                $('#duration_value').text(duration_value);
                $('#from').text(origin);
                $('#to').text(destination);
            }
        }
    }
    $('#distance_form').submit(function (e) {
        e.preventDefault();
        calculateDistance(); 
    });


    $('#Kargo_Tipi').on('change', function () {
        if ($('#Kargo_Tipi').val() === "Koli") {
            $("#koli_ozellikleri").show();
        }
        else {
            $("#koli_ozellikleri").hide();
        }
    });
 

   


});