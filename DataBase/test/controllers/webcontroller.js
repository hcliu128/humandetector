const HumanRepository = require("../repositories/HumanRepository");
const humanRepository = new HumanRepository();
const PushNotify = require('./notify');
class Controller {

    static HomePage = (req, res) => {
        res.send('Wellcome!!');
    }

    static test = (req, res) => {
        humanRepository.getAll().then(async (data) => {
            res.status(200).json(data);
        });
    }

    static async HumanDetectorLog(req, res) {
        try {
            let indata = req.body;
            let message = indata.message;
            console.log(req.body);
            humanRepository.create(message).then(async () => {
                res.status(200).send('ok');
            })
            /*再自行修改傳訊內容及觸發條件*/
            if (message == 1) {
                PushNotify("偵測到有人");
            }
        } catch (error) {
            console.log(error)
            res.status(500).send('error')
        }

    }

    static async HumanDetectorGet(req, res) {
        try {
            humanRepository.getLastOne().then(async (data) => {
                res.status(200).json(data);
            });
        } catch (error) {
            console.log(error);
            res.status(500).send('error')
        }
    }
}
module.exports = Controller;