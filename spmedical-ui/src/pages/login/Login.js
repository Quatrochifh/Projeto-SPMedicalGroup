import { Component } from 'react';
import axios from 'axios';
//import { Link } from 'react-router-dom';
import { parseJwt } from "../../services/auth";

import '../../assets/css/Style.css';

import img from '../../assets/img/drhelena.png'

export default class Login extends Component {
  constructor(props) {
    super(props);
    this.state = {
      email: '',
      senha: '',
      erroMensagem: '',
      isLoading: false,
    };
  };

  efetuaLogin = (event) => {
    // ignora o comportamento padrão do navegador (recarregar a página, por exemplo)
    event.preventDefault();

    this.setState({ erroMensagem: '', isLoading: true });

    // Define a url e o corpo da requisição
    axios.post('http://localhost:5000/api/Login', {
      email: this.state.email,
      senha: this.state.senha,
    })


      // recebe todo o conteúdo da resposta da requisição na variável resposta
      .then((resposta) => {
        // verifico se o status code dessa resposta é igual a 200
        if (resposta.status === 200) {
          // se sim, exibe no console do navegador o token do usuário logado,
          // console.log('Meu token é: ' + resposta.data.token);
          // salva o valor do token no localStorage
          localStorage.setItem('usuario-login', resposta.data.token);

          // e define que a requisição terminou
          this.setState({ isLoading: false });

          // define a variável base64 que vai receber o payload do token
          let base64 = localStorage.getItem('usuario-login').split('.')[1];

          // exibe no console do navegador o valor em base64
          console.log(base64);

          console.log(this.props);

          // verifica se o usuário logado é do tipo administrador
          switch (parseJwt().role) {
            case "1":
              this.props.history.push('/adm')
              break;
            case "2":
              this.props.history.push('/med')
              break;
            case "3":
              this.props.history.push('/paciente')
              break;

            default:
              break;
          }
        }
      })

      // Caso haja um erro,
      .catch(() => {
        // define o valor do state erroMensagem com uma mensagem personalizada
        this.setState({
          erroMensagem: 'E-mail e/ou senha inválidos! Tente novamente',
          isLoading: false,
        });
      });
  };


  atualizaStateCampo = (campo) => {
    // quando estiver digitando no campo username
    //                     email        :       adm@adm.com

    // quando estiver digitando no campo password
    //                     senha        :        senha123
    this.setState({ [campo.target.name]: campo.target.value });
  };




  render() {
    return (
      <div>
        <main className="fundo_cadastrolo">
          {/* Lista de tipos de eventos */}
          <section className="sectionlo">
            <form className="box_Listarlo">

              <h2 className="usu_cadalo">usuario cadastrados</h2>

              <div className="qualquer">
                <div className="retangulos1lo">
                  <img className="imagemfotinholo" src= {img} alt="drhelena"/>
                  <div className="slalo">
                    <span className="nome_listalo">DRA. Helena Strada</span>
                    <span className="que_elo">Medico</span>
                  </div>

                </div>

                <div className="retangulos2lo">
                  <img className="imagemfotinholo" src= {img} alt="drhelena" />
                  <div className="slalo">
                    <span className="nome_listalo">Loren i</span>
                    <span className="que_elo">Medico</span>
                  </div>
                </div>

                <div className="retangulos3lo">
                  <img className="imagemfotinholo" src={img} alt="drhelena" />
                  <div className="slalo">
                    <span className="nome_listalo">Fernando</span>
                    <span className="que_elo">Paciente</span>
                  </div>
                </div>
              </div>
            </form>

            <form/>
 
 <form className="box_cadastrolo">

     <h2 className="usu_cadalo">cadastrar</h2>


     <input 
     className= "cadastro_elo"
     placeholder="Email"
     type="text"
     name="Email"
     id="cadastro__email"/>
     

    <input
         className= "cadastro_slo"
         placeholder="Senha"
         type="password"
         name="Senha"
         id="cadastro__senha"/>

      <input 
         className="cadastro_clo"
         type="text"
         name="cpf" 
   pattern="\d{3}\.\d{3}\.\d{3}-\d{2}" 
    placeholder="Digite um CPF no formato: xxx.xxx.xxx-xx"
        id="cadastro__id"/>

         <button className="btn__cadastrolo" id="btn__cadastro" href="#">Cadastre-se</button>
         <span className="faca_loginlo">Não tem uma conta? faça <span class="verde_lo">Cadastro</span></span>
     
 </form>
 </section>
</main>
</div>
)}
}