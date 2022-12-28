const express = require('express');
const Controller = require('../controllers/webcontroller');

class WebRoutes {
    router = express.Router();

    constructor() {
        this.router.get('/',Controller.HomePage);
        this.router.get('/test', Controller.test);
        this.router.post('/HumanDetector/log', Controller.HumanDetectorLog);
        this.router.get('/HumanDetector/get',Controller.HumanDetectorGet);
    }

}
module.exports = WebRoutes;