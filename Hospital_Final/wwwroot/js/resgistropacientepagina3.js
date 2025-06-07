document.addEventListener("DOMContentLoaded", mostrarPacientes);

function agregarOEditarPaciente() {
    let indice = document.getElementById("indiceEditar").value;
    let paciente = {
        nombres: document.getElementById("Nombres").value,
        apellidos: document.getElementById("Apellidos").value,
        edad: document.getElementById("Edad").value,
        sexo: document.getElementById("Sexo").value,
        diagnostico: document.getElementById("Diagnostico").value
    };

    let pacientes = JSON.parse(localStorage.getItem("pacientes")) || [];

    if (indice === "-1") {
        // Agregar paciente nuevo
        pacientes.push(paciente);
    } else {
        // Editar paciente existente
        pacientes[indice] = paciente;
        document.getElementById("indiceEditar").value = "-1";
    }

    localStorage.setItem("pacientes", JSON.stringify(pacientes));
    mostrarPacientes();
    limpiarFormulario();
}

function mostrarPacientes() {
    let pacientes = JSON.parse(localStorage.getItem("pacientes")) || [];
    let tbody = document.querySelector("#tablaPacientes tbody");
    tbody.innerHTML = "";
    pacientes.forEach((p, index) => {
        let fila = `<tr>
                        <td>${p.nombres}</td>
                        <td>${p.apellidos}</td>
                        <td>${p.edad}</td>
                        <td>${p.sexo}</td>
                        <td>${p.diagnostico}</td>
                        <td>
                            <button class="btn editar" onclick="editarPaciente(${index})">Editar</button>
                            <button class="btn eliminar" onclick="eliminarPaciente(${index})">Eliminar</button>
                        </td>
                    </tr>`;
        tbody.innerHTML += fila;
    });
}

function editarPaciente(index) {
    let pacientes = JSON.parse(localStorage.getItem("pacientes"));
    let paciente = pacientes[index];

    document.getElementById("Nombres").value = paciente.nombres;
    document.getElementById("Apellidos").value = paciente.apellidos;
    document.getElementById("Edad").value = paciente.edad;
    document.getElementById("Sexo").value = paciente.sexo;
    document.getElementById("Diagnostico").value = paciente.diagnostico;
    document.getElementById("indiceEditar").value = index;
}

function eliminarPaciente(index) {
    let pacientes = JSON.parse(localStorage.getItem("pacientes"));
    pacientes.splice(index, 1);
    localStorage.setItem("pacientes", JSON.stringify(pacientes));
    mostrarPacientes();
}

function limpiarFormulario() {
    document.getElementById("pacienteForm").reset();
    document.getElementById("indiceEditar").value = "-1";
}

function cancelarEdicion() {
    limpiarFormulario();
}
