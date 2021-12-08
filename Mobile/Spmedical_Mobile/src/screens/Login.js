import AsyncStorage from '@react-native-async-storage/async-storage';

import React, { Component } from 'react';
import { StyleSheet, ImageBackground, View, TextInput, TouchableOpacity, Text } from 'react-native'
import api from '../services/api';
import jwtDecode from 'jwt-decode';


export default class Login extends Component {
  constructor(props) {
    super(props);
    this.state = {
      email: 'roberto.possarle@spmedicalgroup.com.br',
      senha: 'possarle456',
    };
  }

  realizarLogin = async () => {

    console.warn(this.state.email + ' ' + this.state.senha);

    const resposta = await api.post('/login', {
      email: this.state.email, //adm@spmedicalgroup.com.br
      senha: this.state.senha, //adm4545
    });

    console.warn('Requisição feita')

    const token = resposta.data.token;
    await AsyncStorage.setItem('userToken', token);

    if (resposta.status == 200) {
      console.warn('Login Realizado');
      //this.props.navigation.navigate('');

      console.warn(jwtDecode(token).role);

      var regra = jwtDecode(token).role

      console.warn("chegou aui" + regra)



      switch (regra) {
        case "2":
          console.warn('certo3');
          this.props.navigation.navigate('Medico');
          break;
        case "3":
          console.warn('certo2');
          this.props.navigation.navigate('Paciente');
          break;

        default:
          break;
      }
    }

    //  console.warn(token);

  };

  render() {
    return (
      <ImageBackground

        source={require('../../assets/Login.png')}
        style={StyleSheet.absoluteFillObject}>


        <View style={StyleSheet.absoluteFillObject}>
          <View style={styles.main}>

            <TextInput
              style={styles.inputLogin}
              placeholder="E-mail"
              placeholderTextColor="#000"
              keyboardType="email-address"
              onChangeText={email => this.setState({ email })}
            />

            <TextInput
              style={styles.inputLogin}
              placeholder="Senha"
              placeholderTextColor="#000"
              keyboardType="default"
              secureTextEntry={true}
              onChangeText={senha => this.setState({ senha })}
            />

            <TouchableOpacity
              style={styles.btnLogin}
              onPress={this.realizarLogin}>
              <Text style={styles.btnLoginText}>ENTRAR</Text>
            </TouchableOpacity>

          </View>
        </View>

      </ImageBackground>
    )
  }
}


const styles = StyleSheet.create({

  overlay: {
    ...StyleSheet.absoluteFillObject
  },

  main: {
    flex: 1,
    //backgroundColor: '#F1F1F1', retirar pra nao ter conflito.
    justifyContent: 'center',
    alignItems: 'center',
    width: '100%',
    height: '100%',
  },

  mainImgLogin: {
    //confirmar que sera branco
    height: 105, //altura
    width: 110, //largura img nao é quadrada
    margin: 60, //espacamento em todos os lados,menos pra cima.
    marginTop: 0, // tira espacamento pra cima
  },

  inputLogin: {
    width: 230,
    height: 40,
    marginBottom: 40,
    fontSize: 18,
    color: '#000',
    borderBottomColor: '#FFF',
    borderBottomWidth: 2,
    backgroundColor: '#FFF'
  },

  btnLoginText: {
    fontSize: 12, //aumentar um pouco
    fontFamily: 'Sarabun', //troca de fonte
    fontStyle: 'normal',
    fontWeight: 'bold',
    color: '#000', //mesma cor identidade
    letterSpacing: 1, //espacamento entre as letras
    textTransform: 'uppercase', //estilo maiusculo
  },
  btnLogin: {
    alignItems: 'center',
    justifyContent: 'center',
    height: 30,
    width: 100,
    backgroundColor: '#3DC874',
    borderColor: '#000',
    borderWidth: 1,
    borderRadius: 4,
    shadowOffset: { height: 1, width: 1 },
  },
});