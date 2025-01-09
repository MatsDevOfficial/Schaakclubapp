document.addEventListener("DOMContentLoaded", function() {
    // Evenementen voorbeeld
    const events = [
        { name: "Schaaktoernooi 1", date: "2025-02-20" },
        { name: "Schaaktoernooi 2", date: "2025-03-15" }
    ];

    const eventList = document.getElementById('eventList');
    events.forEach(event => {
        const li = document.createElement('li');
        li.textContent = `${event.name} - ${event.date}`;
        eventList.appendChild(li);
    });

    // RSVP formulier verzenden
    const form = document.getElementById('rsvpForm');
    form.addEventListener('submit', function(event) {
        event.preventDefault();
        const name = document.getElementById('name').value;
        const email = document.getElementById('email').value;

        alert(`Bedankt voor je aanmelding, ${name}! We sturen een bevestiging naar ${email}.`);
    });

    // Beheerderspaneel tonen/ verbergen
    const adminLink = document.getElementById('adminLink');
    const adminPanel = document.getElementById('adminPanel');
    
    adminLink.addEventListener('click', function(event) {
        event.preventDefault();
        const adminPassword = prompt("Voer het beheerderswachtwoord in:");
        if (adminPassword === "admin123") {
            adminPanel.style.display = 'block';  // Toont het beheerderspaneel
        } else {
            alert("Onjuist wachtwoord.");
        }
    });

    // Evenement toevoegen via beheerderspaneel
    const addEventForm = document.getElementById('addEventForm');
    addEventForm.addEventListener('submit', function(event) {
        event.preventDefault();
        const eventName = document.getElementById('eventName').value;
        const eventDate = document.getElementById('eventDate').value;

        // Evenement toevoegen aan de lijst
        const li = document.createElement('li');
        li.textContent = `${eventName} - ${eventDate}`;
        document.getElementById('adminEventList').appendChild(li);

        // Evenement aan de front-end toevoegen
        const newEvent = { name: eventName, date: eventDate };
        events.push(newEvent);
    });
});
