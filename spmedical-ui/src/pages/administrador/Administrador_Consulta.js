//import '../../assets/css/Style.css';
import { Component } from 'react';
import axios from "axios";

//import img from '../../assets/img/drhelena.png'



export default class Administrador extends Component {
    constructor(props) {
        super(props);
        this.state = {
            IdPaciente: '',
            IdMedico: '',
            IdSituacao: '3',
            dataConsulta: new Date(),
            descricaoConsulta: ''
        };
    };



    cadastrarConsulta = (event) => {
        event.preventDefault();

        let consulta = {
            IdPaciente: this.state.IdPaciente,
            IdMedico: this.state.IdMedico,
            dataConsulta: new Date(this.state.dataConsulta),
            IdSituacao: this.state.IdSituacao,
            descricaoConsulta: this.state.descricaoConsulta
        };
        axios.post("http://localhost:5000/api/consultas", consulta, {
            headers: {
                'Authorization': 'Bearer ' + localStorage.getItem('usuario-login')
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
    }

    atualizaStateCampo = (campo) => {
        this.setState({ [campo.target.name]: campo.target.value })
    }




    render() {
        return (
            <div>
                <main class="fundo_cadastroadm">
                    <section class="sectionadm">

                        <form onSubmit={this.cadastrarConsulta} class="box_cadastroadm">

                            <h2 class="usu_cadaadm">cadastrar</h2>


                            <input class="cadastro_padm" value={this.state.IdPaciente} onChange={this.atualizaStateCampo} placeholder="       ID Paciente" type="text" name="IdPaciente"
                                id="Consuta__NomePac" />


                            <input class="cadastro_madm"  value={this.state.IdMedico} onChange={this.atualizaStateCampo} placeholder="       ID Medico" type="text" name="IdMedico"
                                id="Consuta__NomeMed" />


                            {/* <div class="Situação_abre">

                                <select  value={this.state.IdSituacao} onChange={this.atualizaStateCampo} name="IdSituacao" id="">
                                    <option value="" disabled selected>Situação</option>
                                    <option value="ad" >Realizada</option>
                                    <option value="med" >Agendada</option>
                                    <option value="pac">Cancelada</option>
                                </select>

                            </div> */}

                            <input class="cadastro_dadm" value={this.state.dataConsulta} onChange={this.atualizaStateCampo} placeholder="       Data do agendamento da consulta" type="date"
                                name="dataConsulta" id="Consuta__NomeMed" />

                            <input class="cadastro_dcadm" value={this.state.descricaoConsulta} onChange={this.atualizaStateCampo} placeholder="       Descrição da consulta" type="text" name="descricaoConsulta"
                                id="Consuta__NomeMed" />


                            <button class="btn__cadastroadm" type="submit" id="btn__cadastro" href="#">
                                Cadastre-se
                            </button>

                        </form>



                    </section>

                </main>

            </div>
        )
    }

}