
$(document).ready(function () {
    var menu = document.getElementById("navProdutos");
    AtivarMenuNavegacao(menu);
   
    $('#tblProdutos').DataTable({
        "ajax": "js/ExemploDados.txt",
        "columns": [
            { "data": "nome" },
            { "data": "autor" },
            { "data": "tipo" },            
            { "data": "idioma" },
            { "data": "quantidade" },
            { "defaultContent": "<a href='#'>Editar Detalhes</a>"}
        ]
    });
});

