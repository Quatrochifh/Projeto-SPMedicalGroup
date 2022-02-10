import { Component } from "react";
import axios from 'axios';

export default class ListarMinhas extends Component {
    constructor(props) {
        super(props);
        this.state = {
            Listar: []
        };
    }

    MinhaConsulta = () => {
        axios.get('https://62055b4c161670001741b9d3.mockapi.io/Consulta', {
            headers: {
                'Authorization': 'Bearer ' + localStorage.getItem('usuario-login')
            }
        })

            .then(resposta => {
                if (resposta.status === 200) {
                    this.setState({ Listar: resposta.data })
                }
            })
            .catch(erro => console.log(erro));
    }

    componentDidMount() {
        this.MinhaConsulta();
    }

    render() {
        return (
            <main class="fundo_cadastromed">
                <section className="sectionmed">
                    <form className="box_Listarmed">
                        <h2 className="usu_cadamed">usuario cadastrados</h2>
                        {
                            this.state.Listar.map((item) => {
                                return (
                                    <div className="qualquermed">
                                        <div className="retangulos1med">
                                            <div className="slamed">
                                                <span className="nome_listamed">{item.idpacienteNavigation.nomePac}</span>
                                            </div>
                                        </div>
                                        <div className="retangulos2med">
                                            <div className="slamed">
                                                <span className="nome_listamed">{item.dataConsulta}</span>
                                            </div>
                                        </div>
                                        <div className="retangulos3med">
                                            <div className="slamed">
                                                <span className="nome_listamed">{item.idsituacaoNavigation.qualSituacao}</span>
                                            </div>
                                        </div>
                                        
                                    </div>
                                )
                            })
                        }

                    </form>
                </section>
            </main>
        );
    }
}

