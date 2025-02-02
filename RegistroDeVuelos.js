document.getElementById('botonRegistro').addEventListener('click', async function() {
    const inputs = document.querySelectorAll('input');
    let todosLlenos = true;

    inputs.forEach(input => {
        if (!input.value) {
            todosLlenos = false;
            input.style.borderColor = 'red';
        } else {
            input.style.borderColor = '';
        }
    });

    if (!todosLlenos) {
        alert('Por favor, complete todos los campos.');
        return;
    }
    
    const fechaHoraSalida = document.getElementById('fecha-hora-salida').value;
    const ciudadSalida = document.getElementById('ciudadSalida').value;
    const fechaHoraLlegada = document.getElementById('fecha-hora-llegada').value;
    const ciudadLlegada = document.getElementById('ciudadLlegada').value;
    const PNR = document.getElementById('PNR').value;
    const fechaAbordaje = document.getElementById('fecha-abordaje').value;
    const horaAbordaje = document.getElementById('hora-abordaje').value;
    const fechaRegistro = document.getElementById('fecha-registro').value;
    try {
        const response = await fetch('http://localhost:5257/api/vuelos/registrarVuelo', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({ fechaHoraSalida, ciudadSalida, fechaHoraLlegada, ciudadLlegada, PNR, fechaAbordaje, horaAbordaje, fechaRegistro })
        });

        if (response.status == 201) {
            const data = await response.json();
            alert("Vuelo registrado.");
        } else {
            alert('Error en el servidor');
        }
    } catch (error) {
        console.error('Error en la solicitud:', error);
        alert('Hubo un problema al intentar hacer login.');
    }


});