const path = require('path');

module.exports = {
    entry: path.join(__dirname, 'App/app.ts'),
    output: {
        filename: 'app.js',
        path: path.resolve(__dirname, 'wwwroot/js'),
    },
    mode: 'production',
    optimization: {
        minimize: false,
    },
    module: {
        rules: [
            {
                test: /\.tsx?$/,
                use: 'ts-loader',
                exclude: /node_modules/
            }
        ]
    },
    resolve: {
        extensions: ['.tsx', '.ts', '.js']
    }
}