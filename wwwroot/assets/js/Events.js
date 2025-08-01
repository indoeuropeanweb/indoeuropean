const EventDataJSON = [
    {
        "id": 1,
        "title": "Study in Europe Virtual Event",
        "type_Label": "Online",
        "date": "Aug 02, 2025",
        "time": "11:00 AM - 06:00 PM",
        "location": "N/A",
        "event_banner": "/assets/images/events/events/europe.jpg",
        "type": "online",
        "location_value": "",
        "zoom_id": "910 2227 8457"
    },
    {
        "id": 2,
        "title": "Study in Latvia",
        "type_Label": "In-Person",
        "date": "Aug 30, 2025",
        "time": "10:00 AM - 01:00 PM",
        "location": "Delhi  (Tower-2)",
        "event_banner": "/assets/images/events/events/latvia.jpg",
        "type": "inperson",
        "location_value": "new-delhi",
        "zoom_id": "N/A"
    },
    {
        "id": 3,
        "title": "Study in Lithuania",
        "type_Label": "In-Person & Online",
        "date": "Aug 31, 2025",
        "time": "10:00 AM - 01:00 PM",
        "location": "Chandigarh",
        "event_banner": "/assets/images/events/events/lithuania.jpg",
        "type": "both",
        "location_value": "chandigarh",
        "zoom_id": "910 2227 8457"
    },
]


$(document).ready(function () {
    const searchEvent = $("#search-event");
    const typeEvent = $("#event-type-selection");
    const locationEvent = $("#event-location-selection");

    RenderAllEvents(EventDataJSON);

    function applyFilters() {
        const searchValue = searchEvent.val().trim().toLowerCase();
        const typeValue = typeEvent.val().trim().toLowerCase();
        const locationValue = locationEvent.val().trim().toLowerCase();

        const filteredEvents = EventDataJSON.filter((event) => {
            const matchesSearch = !searchValue || event.title.trim().toLowerCase().includes(searchValue);
            const matchesType = !typeValue || event.type.trim().toLowerCase().includes(typeValue);
            const matchesLocation = !locationValue || event.location_value.trim().toLowerCase().includes(locationValue);

            return matchesSearch && matchesType && matchesLocation;
        });

        RenderAllEvents(filteredEvents);
    }

    searchEvent.on("keyup", applyFilters);
    typeEvent.on("change", applyFilters);
    locationEvent.on("change", applyFilters);

    function RenderAllEvents(eventData) {

        const container = $('#Events-Container');
        container.empty(); 

        if (eventData.length === 0) {
            container.append(`<p class="notfound_text">No events found !</p>`);
            return;
        }

        $.each(eventData, function (index, event) {
            $('#Events-Container').append(`
  <div class="feature-card" id="${event.id}">
                        <div class="feature-icon">
                            <div class="event-bg">
                            <img class="w-100" src="${event.event_banner}" alt="${event.title}" loading="lazy" />
                            </div>
                        </div>
                        <div class="event-content">
                         <span>${event.type_Label}</span>
                         <h3>${event.title}</h3>
                         <ul>
                            <li><i class="fa-regular fa-calendar-days"></i>&nbsp;${event.date}</li>
                            <li><i class="fa-regular fa-clock"></i>&nbsp;${event.time}</li>
                            <li><i class="fa-solid fa-location-crosshairs"></i>&nbsp; ${event.location}</li>
                            <li><i class="fa-solid fa-video"></i>&nbsp; ${event.zoom_id}</li>
                         </ul>
                        <button>View Details &nbsp;<i class="fa-solid fa-angle-right"></i> </button>
                        </div>
                    </div>
  `);
        });

    }

});



