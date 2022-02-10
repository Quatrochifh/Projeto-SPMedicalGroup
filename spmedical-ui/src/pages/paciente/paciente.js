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
                                                <span className="nome_listapac">{item.iDMedicoNavigation.NomeMedico}</span>
                                            </div>
                                        </div>
                                        <div className="retangulos2pac">
                                            <div className="slapac">
                                                <span className="nome_listapac">{item.DataConsulta}</span>
                                            </div>
                                        </div>
                                        <div className="retangulos3pac">
                                            <div className="slapac">
                                                <span className="nome_listapac">{item.DescricaoConsulta}</span>
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

