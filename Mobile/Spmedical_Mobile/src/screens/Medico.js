import api from '../services/api';
import React, {Component} from 'react';
import {
    StyleSheet, ImageBackground, View, Image, TextInput, TouchableOpacity, Text, FlatList,
} from 'react-native';
import AsyncStorage from '@react-native-async-storage/async-storage';

export default class Projetos extends Component {
    constructor(props) {
        super(props);
        this.state = {
            Lista: []
        }
    };

    BuscarProjetos = async () => {
        const Token = await AsyncStorage.getItem('userToken')
        const resposta = await api.get('/consultas', {
            headers: {
                'Authorization' : 'Bearer ' + Token
            }
        });

        if(resposta.status == 200){
            const dadosApi = resposta.data; 
            this.setState({ Lista: dadosApi })
            console.warn(this.state.Lista);
        }
    }

    componentDidMount() {
        this.BuscarProjetos();
    }

    render() {
        return(
            <ImageBackground source={require('../../assets/Medico.png')}
            style={StyleSheet.absoluteFillObject}>
        

        <View style={styles.main}>
        <View style={styles.main}>
        <View style={styles.Meu_titulo}>
            
        <Text style={styles.consultas}>MINHAS CONSULTAS</Text>
        <View style={styles.linha}></View>
        </View>
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
                <Text style={styles.Descricao}>{item.dataConsulta}</Text>
            </View>
            <Text style={styles.descricao}>
                {item.descricaoConsulta}
            </Text>
        </View>
    )

}




const styles = StyleSheet.create({

    overlay: {
        ...StyleSheet.absoluteFillObject, //todas as prop do styleShhet, e vamos aplica o abosluteFIL...
        // backgroundColor: 'rgba(183,39,255,0.79)', //rgba pq vamos trabalhar com transparencia.
      },

    main: {
        justifyContent: 'center',
        alignItems: 'center',
        width: '100%',
        height: '100%',
    },

    consultas: {
        width1: 30,
        justifyContent: 'flex-end'

    },

    

    
})