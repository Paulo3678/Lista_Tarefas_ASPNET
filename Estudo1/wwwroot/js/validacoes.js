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

function CamposParaValidar(campos) {

    campos.forEach(campo => {
        const campo_element = $(campo.id);
        const valor_campo = $(campo.id).val();
        console.log(campo_element.next());
        if (valor_campo == null || valor_campo == "") {
            if (!$(campo.id).next().hasClass("text-danger")) {
                let novo = $("<span class='text-danger d-block'>Esse campo eh requerido!</span > ");
                novo.insertBefore(campo_element);
            }
        }

        console.log($(campo.id).next());

    });
}