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
        axios.get('http://localhost:5000/api/consultas', {
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
            <main class="fundo_cadastropac">
                <section className="sectionpac">
                    <form className="box_Listarpac">
                        <h2 className="usu_cadapac">usuario cadastrados</h2>
                        {
                            this.state.Listar.map((item) => {
                                return (
                                    <div className="qualquerpac">
                                        <div className="retangulos1pac">
                                            <div className="slapac">
                                                <span className="nome_listapac">{item.idmedicoNavigation.nomeMedico}</span>
                                            </div>
                                        </div>
                                        <div className="retangulos2pac">
                                            <div className="slapac">
                                                <span className="nome_listapac">{item.dataConsulta}</span>
                                            </div>
                                        </div>
                                        <div className="retangulos3pac">
                                            <div className="slapac">
                                                <span className="nome_listapac">{item.idsituacaoNavigation.qualSituacao}</span>
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

