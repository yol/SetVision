﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Emgu.CV;
using Emgu.CV.ML;

namespace SetVision.Learning
{
    internal static class ClassifierUtils
    {
        public static void GenerateTrainMatrices(IDictionary<float[], int> trainpairs, 
            out Matrix<float> vectors, 
            out Matrix<float> classes)
        {
            List<float[]> samples = new List<float[]>(trainpairs.Keys);

            int dimension = samples[0].Length;
            vectors = new Matrix<float>(trainpairs.Count, dimension);
            classes = new Matrix<float>(trainpairs.Count, 1);

            for (int sample_index = 0; sample_index < trainpairs.Count; sample_index++)
            {
                float[] sample = samples[sample_index];
                for (int i = 0; i < dimension; i++)
                {
                    vectors[sample_index, i] = sample[i];
                }

                classes[sample_index, 0] = (float)trainpairs[sample];
            }
        }

        public static Matrix<float> ToMatrix(float[] vector)
        {
            Matrix<float> toClassify = new Matrix<float>(1, vector.Length);
            for (int i = 0; i < vector.Length; i++)
            {
                toClassify[0, i] = vector[i];
            }
            return toClassify;
        }
    }
}
