const path = require('path');

module.exports = {
  mode:'development',
  entry: {
    GestaoOcupacaoModule:'./Scripts/App/Pages/GestaoOcupacao/GestaoOcupacaoController.js',
    GestaoInteressadoModule:'./Scripts/App/Pages/GestaoInteressado/GestaoInteressadoController.js',
  },
  output: {
    filename: '[name].js',
    path: path.resolve(__dirname, 'ScriptsDist'),
  },
};