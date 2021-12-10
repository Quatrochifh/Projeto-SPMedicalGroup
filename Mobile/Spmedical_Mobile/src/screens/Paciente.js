import api from '../services/api';
import React, { Component } from 'react';
import {
    StyleSheet, ImageBackground, View, Image, TextInput, TouchableOpacity, Text
} from 'react-native';

export default class Projetos extends Component {
    constructor(props) {
        super(props);
        this.state = {
            Lista: []
        }
    };

    BuscarProjetos = async () => {
        const resposta = await api.get('/consultas');

        const dadosApi = resposta.data;
        this.setState({ Lista: dadosApi })
    }

    componentDidMount() {
        this.BuscarProjetos();
    }

    render() {
        return (
            <ImageBackground
            source={require('../../assets/Paciente.png')}
            style={StyleSheet.absoluteFillObject}>
    

                <View style={styles.main}>
                    <View style={styles.Meu_titulo}>

                        <Text style={styles.consultas}>MINHAS CONSULTAS</Text>
                        <View style={styles.linha}></View>
                    </View>

                    <FlatList
                    contentContainerStyle={styles.lista}
                    data={this.state.Lista}
                    keyExtractor={item => item.idconsulta}
                    renderItem={this.renderItem}
                />
                </View>

                

            </ImageBackground>

        );
    }

    renderItem = ({ item }) => (
        <View style={styles.container_lista}>
            <View style={styles.container_nomes}>
                <Text style={styles.NomeMedico}>{(item.idmedicoNavigation.nomeMedico)}</Text>
                <Text style={styles.NomePaciente}>{(item.idpacienteNavigation.nomePac)}</Text>
                <Text style={styles.Situacao}>{(item.idsituacaoNavigation.qualSituacao)}</Text>
                <Text style={styles.dataConsulta}>{item.dataConsulta}</Text>
            </View>
            <Text style={styles.descricao}>
                {item.descricaoConsulta}
            </Text>
        </View>
    )

}




const styles = StyleSheet.create({

    container_nomes : {
        flex : 1
    },

    nada : {
        flex : 1
    },

    main: {
        justifyContent: 'center',
        alignItems: 'center',
        width: '100%',
        height: '100%',
    },

    consultas: {
        widthi: '10%',
        color: '#FF00E5',
        fontSize: 25,


    },

    linha: {
        width: '60%',
        backgroundColor: 'purple',
        height: 3,
        marginBottom: 10
    },

    Meu_titulo: {
        justifyContent: 'space-between',
        alignItems: 'center',
        marginTop: '15%',
        // marginBottom: '97%',
        height: '5%',
        width: '100%'
    },

    container_lista: {
        // height: '40%',
        flex : 1,
        backgroundColor: '#f1f1f1',
        borderRadius: 10,
        paddingLeft: 5,
        marginTop: 50,
    },

    NomeMedico: {
        fontSize: 15,
        fontFamily: 'Roboto',
        color: '#000',
        fontWeight: '400',
    },

    NomePaciente: {
        fontSize: 15,
        fontFamily: 'Roboto',
        color: '#000',
        fontWeight: '400',
    },

    Situacao: {
        fontSize: 15,
        fontFamily: 'Roboto',
        color: '#000',
        fontWeight: '400',
    },

    dataConsulta: {
        fontSize: 15,
        fontFamily: 'Roboto',
        color: '#000',
        fontWeight: '400',
    }




})