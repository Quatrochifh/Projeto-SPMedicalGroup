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
            <ImageBackground source={require('../../assets/Paciente.png')}
                style={StyleSheet.absoluteFillObject}>

                <View style={styles.main}>

                    <Text style={styles.cima}>LISTAR AS MINHAS CONSULTA</Text>


                </View>
            </ImageBackground>


        );

    }
}

const styles = StyleSheet.create({

    main: {
        justifyContent: 'center',
        alignItems: 'center',
        width: '100%',
        height: '100%',
    },

    cima: {

    }


})