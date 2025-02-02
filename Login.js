document.getElementById('botonLogin').addEventListener('click', async function() {
    const correo = document.getElementById('correo').value;
    const contrasena = document.getElementById('contrasena').value;
    
    if (!correo || !contrasena) {
        alert("Por favor, ingresa todos los campos.");
        return;
    }

    try {
        const response = await fetch('http://localhost:5257/api/vuelos/login', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({ correo, contrasena })
        });

        if (response.ok) {
            const data = await response.json();
            if (data.success) {
                window.location.href = "C:/Users/danie/repos/BitacoraDeVuelos/registroDeVuelo.html";
            } else {
                alert('Credenciales incorrectas');
            }
        } else {
            alert('Error en el servidor');
        }
    } catch (error) {
        console.error('Error en la solicitud:', error);
        alert('Hubo un problema al intentar hacer login.');
    }
});