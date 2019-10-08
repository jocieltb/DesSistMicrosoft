var Tabuleiro;
        function Jogar(posX, posY) {
            var xhttp = new XMLHttpRequest();
            var posX = 0;
            var posY = 0;
            xhttp.onreadystatechange = function () {
                if (this.readyState == 4 && this.status == 200) {
                    ObterJogo();
                }
            };
            xhttp.open("GET", "/api/JogoDaVelha/" + Tabuleiro.jogadorAtual + "/" + posX + "/" + posY, true);
            xhttp.send();
        }
        function IniciarJogo() {
            var xhttp = new XMLHttpRequest();
            xhttp.onreadystatechange = function () {
                if (this.readyState == 4 && this.status == 200) {
                    alert("Jogo Reiniciado!");
                    ObterJogo();
                }
            };
            xhttp.open("GET", "/api/JogoDaVelha/Reset", true);
            xhttp.send();
        }
        function ObterJogo() {
            var xhttp = new XMLHttpRequest();
            xhttp.onreadystatechange = function () {
                if (this.readyState == 4 && this.status == 200) {
                    Tabuleiro = this.response;
                }
            };
            xhttp.open("GET", "/api/JogoDaVelha/", true);
            xhttp.send();
        }