const EventDataJSON = [
    {
        id: 1,
        title: "Study in Lithuania Spot Admission Day (New Delhi)",
        type_Label: "In-Person",
        date: "Apr 5th, 2026",
        time: "02:00 PM - 06:30 PM",
        location: "First Floor, 18/1 -A, Jail Road, Opposite Tilak Nagar Metro Station Gate no - 4, Above Sona Baker, Tilak Nagar",
        event_banner: "/assets/images/events/events/Study-in-Lithuania-Event.jpg",
        type: "inperson",
        location_value: "new-delhi",
        zoom_id: "910 2227 8457",
        whatsapp_id: "+91 96501 33355",
        direct_url: "landing-page/eventpage/lithuania-spot-admission-day/",
        btn_text: "Register Now"
    },
    //{
    //    id: 1,
    //    title: "Study in Europe Day (Ludhiana)",
    //    type_Label: "In-Person",
    //    date: "Mar 1st, 2026",
    //    time: "10:30 AM - 05:30 PM",
    //    location: "2nd Floor, SCO -27, Adjacent to Park Plaza Hotel, Near Biryani by Kilo, Feroz Gandhi Market, Jila Kacheri Area, Model Gram, Ludhiana, Punjab - 141001.",
    //    event_banner: "/assets/images/events/events/Europe-Day-Ludhiana.jpeg",
    //    type: "inperson",
    //    location_value: "ludhiana",
    //    zoom_id: "N/A",
    //    whatsapp_id: "+91 96501 33355",
    //    direct_url: "landing-page/eventpage/study-in-europe-day",
    //    btn_text: "Register Now"
    //},
    //{
    //    id: 2,
    //    title: "Study in Europe Day (Jalandhar)",
    //    type_Label: "In-Person",
    //    date: "Mar 2nd, 2026",
    //    time: "10:30 AM - 05:30 PM",
    //    location: "SCO 11-12, Basement, Axis Bank, Crystal Plaza, ITI College Road, Choti Baradari Part 1, Jalandhar, Punjab - 144022.",
    //    event_banner: "/assets/images/events/events/Europe-Day-Jalandhar.jpeg",
    //    type: "inperson",
    //    location_value: "jalandhar",
    //    zoom_id: "N/A",
    //    whatsapp_id: "+91 96501 33355",
    //    direct_url: "landing-page/eventpage/study-in-europe-day",
    //    btn_text: "Register Now"
    //},
    //{
    //    id: 3,
    //    title: "Study in Europe Day (Amritsar)",
    //    type_Label: "In-Person",
    //    date: "Mar 3rd, 2026",
    //    time: "10:30 AM - 05:30 PM",
    //    location: "near Khalsa Women College, Nikah Singh Colony, Amritsar, Punjab - 143002.",
    //    event_banner: "/assets/images/events/events/Europe-Day-Amritsar.jpeg",
    //    type: "inperson",
    //    location_value: "amritsar",
    //    zoom_id: "N/A",
    //    whatsapp_id: "+91 96501 33355",
    //    direct_url: "landing-page/eventpage/study-in-europe-day",
    //    btn_text: "Register Now"
    //},
    //{
    //    id: 1,
    //    title: "Study in Europe Day (New Delhi)",
    //    type_Label: "In-Person",
    //    date: "Mar 7th, 2026",
    //    time: "10:30 AM - 05:30 PM",
    //    location: "First Floor, 18/1-A, Jail Road, Opp. Tilak Nagar Metro Station Gate No. 4, Above Sona Baker, New Delhi – 110018",
    //    event_banner: "/assets/images/events/events/Europe-Day-HO.jpeg",
    //    type: "inperson",
    //    location_value: "new-delhi",
    //    zoom_id: "N/A",
    //    whatsapp_id: "+91 96501 33355",
    //    direct_url: "landing-page/eventpage/study-in-europe-day",
    //    btn_text: "Register Now"
    //},
    //{
    //    id: 1,
    //    title: "Study in Europe Day (Patiala)",
    //    type_Label: "In-Person",
    //    date: "Mar 10th, 2026",
    //    time: "10:30 PM - 05:30 PM",
    //    location: "SCO#89, Second & Third Floor, New Leela Bhawan Patiala, Punjab - 147001.",
    //    event_banner: "/assets/images/events/events/Europe-Day-Patiala.jpeg",
    //    type: "inperson",
    //    location_value: "patiala",
    //    zoom_id: "N/A",
    //    whatsapp_id: "+91 96501 33355",
    //    direct_url: "landing-page/eventpage/study-in-europe-day",
    //    btn_text: "Register Now"
    //},
    //{
    //    id: 2,
    //    title: "Study in Europe Day (Chandigarh)",
    //    type_Label: "In-Person",
    //    date: "Mar 11th, 2026",
    //    time: "10:30 AM - 05:30 PM",
    //    location: "SCO NO.64-65, 2nd Floor, Near Oyster Hotel, Sector 17A, Chandigarh, Punjab - 160017.",
    //    event_banner: "/assets/images/events/events/Europe-Day-Chandigarh.jpeg",
    //    type: "inperson",
    //    location_value: "chandigarh",
    //    zoom_id: "N/A",
    //    whatsapp_id: "+91 96501 33355",
    //    direct_url: "landing-page/eventpage/study-in-europe-day",
    //    btn_text: "Register Now"
    //}, 
];

$(document).ready(function () {
    const e = $("#search-event"),
        n = $("#event-type-selection"),
        t = $("#event-location-selection");
    function a() {
        const a = e.val().trim().toLowerCase(),
            o = n.val().trim().toLowerCase(),
            s = t.val().trim().toLowerCase();
        i(
            EventDataJSON.filter((e) => {
                const n = !a || e.title.trim().toLowerCase().includes(a),
                    t = !o || e.type.trim().toLowerCase().includes(o),
                    i = !s || e.location_value.trim().toLowerCase().includes(s);
                return n && t && i;
            })
        );
    }
    function i(e) {
        const n = $("#Events-Container");
        n.empty(),
            0 !== e.length
                ? $.each(e, function (e, n) {
                    $("#Events-Container").append(
                        `\n  <div class="feature-card" id="${n.id}">\n  <div class="feature-icon">\n  <div class="event-bg">\n  <img class="w-100" src="${n.event_banner}" alt="${n.title}" loading="lazy" />\n  </div>\n </div>\n <div class="event-content">\n   <span>${n.type_Label}</span>\n <h3>${n.title}</h3>\n <div class="d-flex justify-content-between flex-column" style="height: 280px"><ul>\n <li class="event-icons"><i class="fa-regular fa-calendar-days"></i>&nbsp;${n.date}</li>\n <li class="event-icons"><i class="fa-regular fa-clock"></i>&nbsp;${n.time}</li>\n <li class="event-icons"><i class="fa-solid fa-location-crosshairs"></i>&nbsp; ${n.location}</li>\n <li class="event-icons"><i class="fa-solid fa-video"></i>&nbsp; ${n.zoom_id}</li>\n <li>\n</li>\n  </ul>\n<a class="cursor-pointer event-btn" target="_blank" href="${n.direct_url}">${n.btn_text}</a></div> </div>\n </div>\n`
                    );
                })
                : n.append('<h2 class="notfound_text">Coming soon !</h2>');
    }
    i(EventDataJSON), e.on("keyup", a), n.on("change", a), t.on("change", a);
});
