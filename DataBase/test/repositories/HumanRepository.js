const detection = require('../models').detection;
const Sequelize = require("sequelize");
const Op = Sequelize.Op;

class HumanRepository {
    create = async (message) => {
        return await detection.create({ message });
    }

    getAll = async () => {
        return await detection.findAll({ raw: true });
    }

    getLastOne = async () => {
        return await detection.findOne({   order: [ [ 'createdAt', 'DESC' ]]
        , raw: true });
    }

    getByTimeRange = async (start, end) => {
        return await detection.findAll({
            where: {
                createdAt: {
                    [Op.between]: [start, end]
                }
            },
            raw: true
        })
    }
}

module.exports = HumanRepository;