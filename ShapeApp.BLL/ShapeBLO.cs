﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShapeApp.DAL.ShapeFactory;
using ShapeApp.DAL;
using ShapeApp.DAL.Interfaces;
using ShapeApp.Entities;
using ShapeApp.Common.Interfaces;


namespace ShapeApp.BLL
{
    public class ShapeBLO : ShapeApp.BLL.Interfaces.IShapeBLO, IDisposable
    {
        #region Constructor

        /// <summary>
        /// Class constructor
        /// </summary>
        /// <param name="shape">Shape Dao.</param>
        /// <param name="shapeFactory">Shape Factory,.</param>
        /// <param name="fileReader">File Reader.</param>
        public ShapeBLO(IShapeDAO shape,IShapeFactory shapeFactory, IFileReader fileReader)
        {
            ShapeDAO = shape;
            ShapeFactory = shapeFactory;
            FileReader = fileReader;
        }

        
        #endregion

        /// <summary>
        /// Add a new shape based in a string definition.
        /// </summary>
        /// <param name="shapeDefinition">Shape Definition string.</param>
        /// <returns>Shape</returns>
        public Shape AddShape(string shapeDefinition)
        {
            if(ShapeDAO == null || ShapeFactory == null) return null;

            var shape = ShapeFactory.CreateShape(shapeDefinition);

            if (shape == null) return null;

            ShapeDAO.Insert(shape);

            return shape;
        }

        /// <summary>
        /// Deletes a shjape.
        /// </summary>
        /// <param name="id">Shape's id.</param>
        /// <returns>True if deleted suceessfully, otherwise false.</returns>
        public bool DeleteShape(int id)
        {
            if (ShapeDAO == null) return false;

            return ShapeDAO.Delete(id);
        }

        /// <summary>
        /// Gets all shapes where a point is inside of them.
        /// </summary>
        /// <param name="point">Point</param>
        /// <returns>List of shapes.</returns>
        public IList<Shape> GetShapesInsidePoint(Point point)
        {
            return ShapeDAO.GetShapesInsidePoint(point);
        }

        /// <summary>
        /// Checks if the shapedefinition is valid.
        /// </summary>
        /// <param name="shapeDefinition">String with the shape definition.</param>
        /// <returns>True if valid, otherwise false.</returns>
        public bool IsValid(string shapeDefinition)
        {
            if (ShapeFactory == null) return false;

            return ShapeFactory.IsValid(shapeDefinition);
        }

        /// <summary>
        /// Gets the list of existing shapes.
        /// </summary>
        /// <returns>List of shapes.</returns>
        public IList<Shape> GetAllShapes()
        {
            return ShapeDAO.List().ToList();
        }

        /// <summary>
        /// Loads shapes definitions within a txt file.
        /// </summary>
        /// <param name="path">File's path</param>
        /// <returns>String with the result message.</returns>
        public string LoadShapesFromFile(string path)
        {
            var result = new StringBuilder();

            var definitions = FileReader.ReadAllLines(path);

            if (String.IsNullOrEmpty(definitions)) return String.Empty;

            foreach (var line in definitions.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries))
            {
                var shape = AddShape(line.Trim());

                if (shape == null)
                {
                    result.AppendLine("Line not processed: " + line);
                }
                else 
                    result.AppendLine(shape.ToString());

            }

            return result.ToString();

        }

        public void Dispose()
        {
            if (ShapeDAO != null)
                ShapeDAO.Dispose();
            if (ShapeFactory != null)
                ShapeFactory.Dispose();
            ShapeDAO = null;
            ShapeFactory = null;
            FileReader = null;
        }

        /// <summary>
        /// Shape Dao
        /// </summary>
        public IShapeDAO ShapeDAO { get; set; }

        /// <summary>
        /// Shape Factory
        /// </summary>
        public IShapeFactory ShapeFactory { get; set; }

        /// <summary>
        /// File Reader.
        /// </summary>
        public IFileReader FileReader { get; set; }


       
    }
}
