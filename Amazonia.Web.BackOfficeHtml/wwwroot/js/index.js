﻿function AtualizarValoresPaineis() {
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
    google.charts.load('current', { 'packages': ['corechart', 'bar'] });
    google.charts.setOnLoadCallback(CarregarDadosDoGraficoClientes);

    function CarregarDadosDoGraficoClientes() {

        //Carregar a partir da webapi
        var data = google.visualization.arrayToDataTable([
            ['Dia', ''],
            ['Domingo', 512],
            ['Segunda', 1170],
            ['Terça', 21],
            ['Quarta', 100],
            ['Quinta', 354],
            ['Sexta', 100],
            ['Sábado', 660],
        ]);


        var options = {
            chart: {
                title: 'Clientes Novos'
            }
        };

        var chart = new google.charts.Bar(document.getElementById('imgGraficoClientesNovos'));
        chart.draw(data, options);
    }
}

function AtualizarGraficoEstoque() {
    google.charts.load('current', { 'packages': ['corechart'] });
    google.charts.setOnLoadCallback(CarregarDadosDoGraficoEstoque);


    function CarregarDadosDoGraficoEstoque() {
        //Valor carregado a partir da webapi
        var data = google.visualization.arrayToDataTable([
            ['Livro', 'Quantidade Disponível'],
            ['Harry Potter', 101],
            ['O Senhor do Anéis', 20],
            ['As Crônicas de Gelo e Fogo', 57],
            ['Eragon', 28],
            ['As Crônicas de Nárnia', 70]
        ]);

        var options = {
            title: 'Livros em Estoque'
        };

        var chart = new google.visualization.PieChart(document.getElementById('imgGraficoEstoqueLivros'));
        chart.draw(data, options);
    }
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
