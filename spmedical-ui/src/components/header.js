 import React from 'react';
 import "../assets/css/Style.css";
 import logo from "../assets/img/logo_spmedgroup_v2 1.png";

export default function headerTodos()  {
      return (
        <header>
          <div className="container_div_header">
            <a className="menuHamburger" href="#"><img src= {logo} alt="logo do Site" /></a>
            <a className="logoHeader" href="#"><img src={logo} alt="logo do Site" /></a>
            <nav className="entrar">
              <a href="#" className="span_entrar"><span>entrar</span></a>
            </nav>
          </div>
        </header>
      );
};


// export default class headerTodos extends Component{
//   return (
  
//     <header>
//       <div className="container_div_header">
//         <a className="menuHamburger" href="#"><img src= {logo} alt="logo do Site" /></a>
//         <a className="logoHeader" href="#"><img src={logo} alt="logo do Site" /></a>
//         <nav className="entrar">
//           <a href="#" className="span_entrar"><span>entrar</span></a>
//         </nav>
//       </div>
//     </header>
//   );
// }
