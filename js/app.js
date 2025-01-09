document.addEventListener("DOMContentLoaded", function() {
    // Dynamisch evenementen toevoegen
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
});
