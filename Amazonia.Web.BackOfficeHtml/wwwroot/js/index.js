function AtualizarValoresPaineis() {
    //TODO: Buscar informação da webapi    
    $("#lblNumeroVendas").text("0");
    $("#lblNumeroVendasCanceladas").text("0");
    $("#lblClientesNovos").text("0");
    $("#lblLivrosAesgotar").text("0");
}





function AtualizarGraficoVendas() {
    //Exibe as vendas do último mês num histograma de frequências (Gráfico de Barras)
    google.charts.load('current', { packages: ['corechart', 'bar'] });
    google.charts.setOnLoadCallback(CarregarDadosDoGrafico);


    function CarregarDadosDoGrafico() {
        //Esses valores serão carregados a partir da WebApi (assim que a gente resolver o CORS)
        var data = google.visualization.arrayToDataTable([
            ['Dia', 'Vendas Concretizadas', 'Vendas Canceladas'],
            ['Domingo', 1000, Math.floor(Math.random() * 1000)],
            ['Segunda', 1170, Math.floor(Math.random() * 1000)],
            ['Terça', 660, Math.floor(Math.random() * 1000)],
            ['Quarta', 1030, Math.floor(Math.random() * 1000)],
            ['Quinta', 6160, Math.floor(Math.random() * 1000)],
            ['Sexta', 1660, Math.floor(Math.random() * 1000)],
            ['Sábado', 6601, Math.floor(Math.random() * 1000)],
        ]);


        var options = {
            chart: {
                title: 'Vendas dos Últimos 7 dias'
            },
            hAxis: {
                title: 'Dia do Mês',                
            },
            vAxis: {
                title: 'Número Total de Vendas'
            }
        };

        var materialChart = new google.charts.Bar(document.getElementById('imgGraficoVendas'));
        materialChart.draw(data, options);
    }
}



function AtualizarGraficoClientes() {
    $("#imgGraficoClientesNovos").text("Oi Grafico Clientes Novos");
}

function AtualizarGraficoEstoque() {
    $("#imgGraficoEstoqueLivros").text("Oi Grafico Estoque");
}


$(document).ready(function () {
    var menu = document.getElementById("navHome");
    AtivarMenuNavegacao(menu);
    AtualizarValoresPaineis();
    AtualizarGraficoVendas();
    AtualizarGraficoClientes();
    AtualizarGraficoEstoque();

    $("#btnLogin").click(function () {
        ExibirPainelDeLogin();
    });
});



function ExibirPainelDeLogin() {
    Swal.fire({
        title: 'Submit your Github username',
        input: 'text',
        inputAttributes: {
            autocapitalize: 'off'
        },
        showCancelButton: true,
        confirmButtonText: 'Logar',
        showLoaderOnConfirm: true,
        preConfirm: (login) => {
            return fetch(`//api.github.com/users/${login}`)
                .then(response => {
                    if (!response.ok) {
                        throw new Error(response.statusText)
                    }
                    return response.json()
                })
                .catch(error => {
                    Swal.showValidationMessage(
                        `Request failed: ${error}`
                    )
                })
        },
        allowOutsideClick: () => !Swal.isLoading()
    }).then((result) => {
        if (result.isConfirmed) {
            Swal.fire({
                title: `${result.value.login}'s avatar`,
                imageUrl: result.value.avatar_url
            })
        }
    })
}




//function AtualizarNumeroVendas() {

//    var settings = {
//        'cache': false,
//        'dataType': "jsonp",
//        "async": false,
//        "crossDomain": true,
//        "url": "https://localhost:44381/api/Vendas",
//        "method": "GET",
//        "headers": {
//            "accept": "application/json",
//            "Access-Control-Allow-Credentials" : "true"
//        }
//    }

//    $.ajax(settings).done(function (response) {
//        $("#lblNumeroVendas").text(response);
//    });
//}
