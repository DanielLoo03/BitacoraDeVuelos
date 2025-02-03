async function cargaDeVuelos() {
    try {
        const respuesta = await fetch('http://localhost:5257/api/vuelos'); 
        if (!respuesta.ok) throw new Error("Error en la respuesta de la API");
        
        const vuelos = await respuesta.json();
        let contenedor = document.getElementById("listaVuelos");
        contenedor.innerHTML = ""; // Limpia contenido 

        vuelos.forEach(vuelo => {
            const vueloDiv = document.createElement("div");
            vueloDiv.classList.add("vuelo");

            vueloDiv.innerHTML = `
                <div>Salida ${vuelo.datetimeSalida}   ${vuelo.ciudadSalida}</div>
                <div>Llegada ${vuelo.datetimeLlegada} ${vuelo.ciudadLlegada}</div>
                <div>Fecha de abordaje ${vuelo.fechaAbordaje}</div>
                <div>Hora de abordaje ${vuelo.horaAbordaje}</div>
                <div>Fecha de registro ${vuelo.fechaRegistro}</div>
                <div>PNR ${vuelo.pnr}</div>
            `;
            contenedor.appendChild(vueloDiv);
        });
    } catch (error) {
        console.error("Error cargando vuelos:", error);
        document.getElementById("listaVuelos").innerHTML = "<p>Error al cargar los vuelos.</p>";
    }
}
cargaDeVuelos();

document.getElementById('botonBusquedaPorPNR').addEventListener('click', async function () {
    let PNR = document.getElementById('busquedaPorPNR').value;
    if (!PNR.trim()) {
        alert("Debes ingresar un PNR primero.");
        return;
    }

    try {
        let response = await fetch(`http://localhost:5257/api/vuelos/${PNR}`, {
            method: 'GET',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            }
        });

        if (response.status === 404) {
            alert('Vuelo no encontrado.');
            return;
        }

        if (!response.ok) {
            throw new Error(`Error en la solicitud: ${response.status}`);
        }

        let vuelo = await response.json();
        if (!vuelo) return;

        let contenedor = document.getElementById("listaVuelos");
        contenedor.innerHTML = "";

        const vueloDiv = document.createElement("div");
        vueloDiv.classList.add("response");
        vueloDiv.innerHTML = `
            <div>Salida ${vuelo.datetimeSalida}   ${vuelo.ciudadSalida}</div>
            <div>Llegada ${vuelo.datetimeLlegada} ${vuelo.ciudadLlegada}</div>
            <div>Fecha de abordaje ${vuelo.fechaAbordaje}</div>
            <div>Hora de abordaje ${vuelo.horaAbordaje}</div>
            <div>Fecha de registro ${vuelo.fechaRegistro}</div>
            <div>PNR ${vuelo.pnr}</div>
        `;

        contenedor.appendChild(vueloDiv);
    } catch (error) {
        console.error('Hubo un problema con la solicitud:', error);
    }
});

document.getElementById('botonMostrarTodos').addEventListener('click', async function () {
    cargaDeVuelos();
});