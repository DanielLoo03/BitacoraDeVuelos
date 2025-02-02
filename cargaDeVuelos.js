async function cargaDeVuelos() {
    try {
        const respuesta = await fetch('http://localhost:5257/api/vuelos'); 
        if (!respuesta.ok) throw new Error("Error en la respuesta de la API");
        
        const vuelos = await respuesta.json();
        const contenedor = document.getElementById("listaVuelos");
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