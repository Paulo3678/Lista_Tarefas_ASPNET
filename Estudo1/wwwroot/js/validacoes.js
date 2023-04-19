$("#formulario-tarefas").on("submit", e => {
    e.preventDefault();

    CamposParaValidar([
        {
            id: "#tituloTarefa"
        },
        {
            id: "#descricaoTarefa"
        }
    ]);
});


document.querySelectorAll(".form-control").forEach(input => {
    input.addEventListener("input", e => {
        const valor_digitado = input.value;
        if (valor_digitado !== "" && valor_digitado !== null) {
            if ($(`#${input.id}`).prev().hasClass("text-danger")) {
                $(`#${input.id}`).prev().remove();
            }
        }
    });
});


function CamposParaValidar(campos) {

    campos.forEach(campo => {
        const campo_element = $(campo.id);
        const valor_campo = $(campo.id).val();

        if (valor_campo == null || valor_campo == "") {
            if (!$(campo.id).prev().hasClass("text-danger")) {
                let novo = $("<span class='text-danger d-block'>Esse campo eh requerido!</span > ");
                novo.insertBefore(campo_element);
            }
        }

    });
}