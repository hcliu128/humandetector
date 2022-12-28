const express = require('express');
const WebRoutes = require('./router/webrouter');
require("dotenv").config();

const app = express();
const port = process.env.PORT
const webRoutes = new WebRoutes();

// middleware
app.use(express.json());

// listen
app.listen(port, function () {
  console.log('listening on port ' + port);
});

// use routers
app.use(webRoutes.router);