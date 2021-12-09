var tema = 0;


function MudarTemaBootstrap() {
    var href = "https://bootswatch.com/5/sandstone/bootstrap.min.css";
    tema++;


    switch (tema) {
        case 1:
            href = "https://bootswatch.com/5/cerulean/bootstrap.min.css"
            break;
        case 2:
            href = "https://bootswatch.com/5/darkly/bootstrap.min.css"
            break;
        case 3:
            href = "https://bootswatch.com/5/cyborg/bootstrap.min.css"
            break;
        default:
            href = "https://bootswatch.com/5/sandstone/bootstrap.min.css";
            tema = 0;
    }

    var title = document.getElementById("meuTitulo");
    title.innerText = href;
    
    var link = document.getElementById("meuCss");
    link.href = href;
}


function AtualizarDisplay() {

    var agora = new Date();
    var hora = agora.getHours();
    var minuto = agora.getMinutes();
    var segundo = agora.getSeconds();

    var title = document.getElementById("meuTitulo");
    title.innerText = hora + ":" + minuto + ":" + segundo;;

}


setInterval('AtualizarDisplay()', 1000);
setInterval('MudarTemaBootstrap()', 10000);