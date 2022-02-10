$(document).ready(function () {

    $("#btnGravar").click(function (e) {

        //form.serialize()
        var dataLocal = {
            "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
            "nome": "string",
            "descricao": "string",
            "autor": "string",
            "tipoLivro": 0,
            "formato": "string",
            "idioma": "string",
            "quantidadeEmEstoque": 0
        };

        //console.debug(dataLocal);
        e.preventDefault(); // avoid to execute the actual submit of the form.

        //var settings = {
        //    url: '',            
        //    method: 'POST',
        //    data: JSON.parse(dataLocal)
        //};

        //$.ajax(settings).done(function (response) {
        //    console.debug(response);
        //});


        $.post("https://localhost:44381/api/Livro", dataLocal)
            .done(function (data) {
                alert("Data Loaded: " + data);
            });

    });
});