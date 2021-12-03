import AsyncStorage from '@react-native-async-storage/async-storage';

import {Component} from 'react';
import api from '../services/api';

export default class Login extends Component {
    constructor(props) {
        super(props);
        this.state = {
            email: '',
            senha: '',
        };
    }

    realizarLogin = async () => {
        //nao temos mais  console log.
        //vamos utilizar console.warn.
    
        //apenas para teste.
        console.warn(this.state.email + ' ' + this.state.senha);
    
        const resposta = await api.post('/login', {
          email: this.state.email, //adm@spmedicalgroup.com.br
          senha: this.state.senha, //adm4545
        });

    const token = resposta.data.token;
    await AsyncStorage.setItem('userToken', token);

    if (resposta.status == 200){
        console.warn('Login Realizado');
        this.props.navigation.navigate('');
    
    }

    console.warn(token);

};

render() {
    return(
      <ImageBackground
  
      source={require('../../assets/Login.png')}
      style={StyleSheet.absoluteFillObject}>
      
      <View>
  
  
  
      </View>
  
      </ImageBackground>
    )
  }
} 