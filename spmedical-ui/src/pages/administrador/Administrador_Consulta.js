//import '../../assets/css/Style.css';
import { Component } from 'react';
import axios from "axios";

//import img from '../../assets/img/drhelena.png'



export default class Administrador extends Component{
    constructor(props){
        super(props);
        this.state = {
            listaConsultas: [],
            listaPacientes: [],
            listaMedicos: [],
            listaSituacao: [],
            listaTodos: [],
            IdPaciente: 0,
            IdMedico: 0,
            IdSituacao: 0,
            dataConsulta: new Date()
        };
    };





    buscaPacientes = () => {
        axios("http://localhost:5000/api/pacientes", {
            headers: {
                'Authorization': 'Bearer ' + localStorage.getItem('usuario-login')
            }
        })
            .then(resposta => {
                if (resposta.status === 200) {
                    this.state({ listaPacientes: resposta.data })
                    console.log(this.state.listaPacientes)
                }
            })
            .catch(erro => console.log(erro))
    }

    buscaMedicos = () => {
        axios("http://localhost:5000/api/medicos", {
            headers: {
                'Authorization': 'Bearer ' + localStorage.getItem('usuario-login')
            }
        })
            .then(resposta => {
                if (resposta.status === 200) {
                    this.state({ listaMedicos: resposta.data })
                    console.log(this.state.listaMedicos)
                }
            })
            .catch(erro => console.log(erro))
    }

    buscaSituacoes = () => {
        axios("http://localhost:5000/api/situacoes", {
            headers: {
                'Authorization': 'Bearer ' + localStorage.getItem('usuario-login')
            }
        })
            .then(resposta => {
                if (resposta.status === 200) {
                    this.state({ listaSituacao: resposta.data })
                    console.log(this.state.listaSituacao)
                }
            })
            .catch(erro => console.log(erro))
    }

    buscaConsultas = () => {
        axios("http://localhost:5000/api/consultas", {
            headers: {
                'Authorization': 'Bearer ' + localStorage.getItem('usuario-login')
            }
        })
            .then(resposta => {
                if (resposta.status === 200) {
                    this.state({ listaConsultas: resposta.data })
                }
            })
            .catch(erro => console.log(erro))
    }

    cadastrarConsulta = (event) => {
        event.preventDefault();

        let consulta = {
            IdPaciente: this.state.IdPaciente,
            IdMedico: this.state.IdMedico,
            dataConsulta: new Date(this.state.dataConsulta),
            IdSituacao: this.state.IdSituacao
        };
        axios.get("http://localhost:5000/api/consultas", consulta, {
            headers: {
                'Authoriztion': 'Bearer' + localStorage.getItem('usuario-login')
            }
        })
            .then(resposta => {
                if (resposta.status === 201) {
                    console.log('foi !!!')
                }
            })
            .catch(erro => {
                console.log(erro);
            })
            .then(this.buscaConsultas);
    }


    componentDidMount() {
        this.buscaConsultas();
        this.buscaPacientes();
        this.buscaMedicos();
        this.buscaSituacoes();
    }

    atualizaStateCampo = (campo) => {
        this.setState({ [campo.target.name]: campo.target.value })
    }




    render(){
        return(
            <div>
                <main class="fundo_cadastroadm">
        <section class="sectionadm">

    <form class="box_cadastroadm">

<h2 class="usu_cadaadm">cadastrar</h2>


<input class="cadastro_padm" placeholder="       Nome Paciente" type="text" name="NomePac"
    id="Consuta__NomePac" />


<input class="cadastro_madm" placeholder="       Nome Medico" type="text" name="NomeMed"
    id="Consuta__NomeMed" />


<div class="Situação_abre">

    <select name="" id="">
        <option value="" disabled selected>Situação</option>
        <option value="ad" >Realizada</option>
        <option value="med" >Agendada</option>
        <option value="pac">Cancelada</option>
    </select>

</div>

<input class="cadastro_dadm" placeholder="       Data do agendamento da consulta" type="text"
    name="NomeMed" id="Consuta__NomeMed" />

<input class="cadastro_dcadm" placeholder="       Descrição da consulta" type="text" name="NomeMed"
    id="Consuta__NomeMed" />


<button class="btn__cadastroadm" id="btn__cadastro" href="#">
    Cadastre-se
</button>

</form>



        </section>

        </main>

            </div>
        )
    }

}