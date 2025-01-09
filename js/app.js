document.addEventListener("DOMContentLoaded", function() {
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

    // RSVP formulier
    const form = document.getElementById('rsvpForm');
    form.addEventListener('submit', function(event) {
        event.preventDefault();
        const name = document.getElementById('name').value;
        const email = document.getElementById('email').value;
        alert(`Bedankt voor je aanmelding, ${name}! We sturen een bevestiging naar ${email}.`);
    });

    // Beheerderspaneel
    const adminLink = document.getElementById('adminLink');
    const adminPanel = document.getElementById('adminPanel');
    
    adminLink.addEventListener('click', function(event) {
        event.preventDefault();
        const adminPassword = prompt("Voer het beheerderswachtwoord in:");
        if (adminPassword === "admin123") {
            adminPanel.style.display = 'block';
        } else {
            alert("Onjuist wachtwoord.");
        }
    });

    const addEventForm = document.getElementById('addEventForm');
    addEventForm.addEventListener('submit', function(event) {
        event.preventDefault();
        const eventName = document.getElementById('eventName').value;
        const eventDate = document.getElementById('eventDate').value;

        const li = document.createElement('li');
        li.textContent = `${eventName} - ${eventDate}`;
        document.getElementById('adminEventList').appendChild(li);

        events.push({ name: eventName, date: eventDate });
    });
});
