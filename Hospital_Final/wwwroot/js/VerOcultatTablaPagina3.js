document.addEventListener("DOMContentLoaded", function () {
    let toggleBtn = document.getElementById("toggleTablaBtn");
    let tablaContainer = document.getElementById("tablaContainer");

    toggleBtn.addEventListener("click", function () {
        if (tablaContainer.style.display === "none") {
            tablaContainer.style.display = "block";
            this.textContent = "Ocultar Tabla";
        } else {
            tablaContainer.style.display = "none";
            this.textContent = "Ver Tabla";
        }
    });
});
