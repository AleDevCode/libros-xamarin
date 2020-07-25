'use strict';

var Libro = require('../models/Libro');
var express = require('express');
var router = express.Router();

// Obtenemos TODAS los libros
// Ruta: my-ip:PORT/libros
// Verbo HTTP: GET
router.get('/', async function (req, res) {
    try {
        const libros = await Libro.findAll();
        res.json(libros);
    } catch (e) {
        res.send(e);
    }
});

// Creamos un libro
// Ruta: my-ip:PORT/libros
// Verbo HTTP: POST
router.post('/', async function (req, res) {
    try {
        let { Titulo, Descripcion, Autor, Genero } = req.body;
        let libro = await Libro.create({
            titulo: Titulo,
            descripcion: Descripcion,
            autor: Autor,
            genero: Genero
        });
        res.json(libro);
    } catch (e) {
        res.send(e);
    }
});

// Obtenemos UN libro por ID
// Ruta: my-ip:PORT/libros/:idLibro
// Verbo HTTP: GET
router.get('/:idLibro', async function (req, res) {
    try {
        const { idLibro } = req.params;
        const { Titulo, Descripcion, Autor, Genero } = req.body;

        let libro = await Libro.findOne({ where: { id: idLibro } });

        return res.json(libro);

    } catch (e) {
        res.send(e);
    }
});

// Actualizamos UN libro por ID
// Ruta: my-ip:PORT/libros/:idLibro
// Verbo HTTP: PUT
router.put('/:idLibro', async function (req, res) {
    try {
        const { idLibro } = req.params;
        const { Titulo, Descripcion, Autor, Genero } = req.body;

        let libroA = await Libro.update(
            {
                titulo: Titulo,
                descripcion: Descripcion,
                autor: Autor,
                genero: Genero
            },
            {
                where: { id: idLibro }
            }
        );

        if (libroA.length > 0) {
            let libro = await Libro.findOne({ where: { id: idLibro } });
            res.json(libro);
        }

    } catch (e) {
        res.send(e);
    }
});

// Eliminamos UN libro por ID
// Ruta: my-ip:PORT/libros/:idLibro
// Verbo HTTP: DELETE
router.delete('/:idLibro', async function (req, res) {
    try {
        const { idLibro } = req.params;
        let libro = await Libro.destroy({
            where: { id: idLibro }
        });
        console.log(libro);
        res.json(libro);
    } catch (e) {
        res.send(e);
    }
});

module.exports = router;