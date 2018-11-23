/**
const path = require('path');
const webpack = require('webpack');
const merge = require('webpack-merge');


module.exports = (env) => {
    const isDevBuild = !(env && env.prod);

    const sharedConfig = () => ({
        stats: { modules: false },
        resolve: { extensions: ['.js', '.vue'] },
        output: {
            filename: '[name].js',
            publicPath: '/dist/'
        },
        module: {
            rules: [
                {
                    test: /\.vue$/,
                    loader: 'vue-loader',
                },
                {
                    test: /\.js$/,
                    loader: 'babel-loader',
                    include: __dirname,
                    exclude: /node_modules/
                },
                { 
                    test: /\.css$/, 
                    loader: "style-loader!css-loader" 
                }
            ]
        }
    });

    const clientBundleOutputDir = './wwwroot/dist';
    const clientBundleConfig = merge(sharedConfig(), {
        entry: { 'main-client': './ClientApp/client.js' },
        output: {
            path: path.join(__dirname, clientBundleOutputDir)
        }
    });

    const serverBundleConfig = merge(sharedConfig(), {
        target: 'node',
        entry: { 'main-server': './ClientApp/server.js' },
        output: {
            libraryTarget: 'commonjs2',
            path: path.join(__dirname, 'wwwroot/dist')
        },
        module: {
            rules: [
                {
                    test: /\.json?$/,
                    loader: 'json-loader'
                }
            ]
        },
    });

    return [clientBundleConfig, serverBundleConfig];
}
**/
var path = require('path');
var webpack = require('webpack');

module.exports = {
  entry: { 'main-client': './ClientApp/app.js' },
  output: {
    path: path.resolve(__dirname, './wwwroot/dist'),
    publicPath: '/dist/',
    filename: 'main-client.js'
  },
  module: {
    rules: [
      { 
        test: /\.vue\.html$/, 
        include: /ClientApp/, 
        loader: 'vue-loader', 
        //options: { loaders: { js: 'awesome-typescript-loader?silent=true' } } 
      },
      {
          test: /\.ts$/,
          include: /ClientApp/, 
          use: 'ts-loader'
      },
      {
        test: /\.vue$/,
        loader: 'vue-loader',
      },
      {
        test: /\.js$/,
        loader: 'babel-loader',
        exclude: /node_modules/
      },
      {
        test: /\.css$/,
        use: [ 'style-loader', 'css-loader' ]
      }
    ]
  },
  plugins: [
    //"syntax-dynamic-import",
    new webpack.ProvidePlugin({
      $: "jquery",
      jQuery: "jquery"
    })
  ]
}
