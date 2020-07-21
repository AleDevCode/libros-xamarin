'use strict';

const { Sequelize } = require('sequelize');
const sequelize = new Sequelize({
    dialect: 'sqlite',
    storage: './storage/database.sqlite'
});

const Libro = sequelize.define('Libro', {
    id: {
        primaryKey: true,
        type: Sequelize.BIGINT,
        autoIncrement: true
    },
    titulo: {
        type: Sequelize.STRING
    },
    descripcion: {
        type: Sequelize.STRING
    },
    autor: {
        type: Sequelize.STRING
    },
    genero: {
        type: Sequelize.STRING
    }
});

Libro.sync();

module.exports = Libro;