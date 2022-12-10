using System;
using System.Collections.Generic;

namespace MyConsole
{
    // You are given an array T of N integers that represents the skill tree.
    //The K-th skill can be learned only if the T[K]-th skill has already been learned.
    //Skill 0 is the root and T[0] = 0.
    //For the example explained above: T[0] = 0, T[1] = 0, T[2] = 1 and T[3] = 1,
    //hence T = [0, 0, 1, 1].
    //for you to do A[i] course you need to have done course T[i]
    //that, given an array T of N integers and an array A of M integers,
    // Write a function that returns the minimum number of skills which have to be learned to acquire all of the skills
    // from the array A in the skill tree T.
    //Examples:
    // 1. Given T = [0, 0, 1, 1] and A = [2], your function should return 3, as explained above.
    // 2. Given T = [0, 0, 0, 0, 2, 3, 3] and A = [2, 5, 6], your function should return 5.
    //To learn skill numbers 2, 5, 6, skills T[2] = 0, T[5] = 3 and T[6] = 3 have to be learned.
    //To learn skill number 3, skill T[3] = 0 has to be acquired. Skill 0 is the root.
    //This gives five skills in total: 2, 5, 6, 3, 0.
    //3. Given T = [0, 0, 1, 2] and A = [1, 2], your function should return 3.
    // Skill number 1 is necessary to unlock skill number 2, and skill number 1 requires skill number 0.
    //That gives three skills in total.
    //4. Given T = [0, 3, 0, 0, 5, 0, 5] and A = [4, 2, 6, 1, 0], your function should return 7.
    // Skills 4, 2, 6, 1 require respectively skills 5, 0, 5, 3. Skills 5 and 3 require skill 0.
    // This gives seven different skills in total that have to be learned in order to acquire all skills from set A.
    // https://1drv.ms/u/s!AgnCgMH3KTKYgdRC3MxU__TJzOzBvA?e=tBisDP
    // https://app.codility.com/public-link/Microsoft-Kenya-SSWEIII-Nov-Interview-Day-2/
    public class SkillTree
    {
        //ideal solution
        public int Solution(int[] T, int[] A)
        {
            var graph = new List<List<int>>();
            //initialize graph
            foreach (var curCourse in T)
            {
                graph.Add(new List<int>());
            }

            //starting at 1 since course 0 has no prerequisite

            for (int i = 1; i < T.Length; i++)
            {
                //prerequisite is the key :  courses are the values
                graph[T[i]].Add(i);
            }

            var set = new HashSet<int>();
            //add root 0
            set.Add(0);
            for (int i = 0; i < A.Length; i++)
            {
                //add target skills
                set.Add(A[i]);
                for (int j = 0; j < graph.Count; j++)
                {
                    //if target skill found get prerequisite skill and add to set
                    if (graph[j].Contains(A[i]))
                    {
                        //add prerequisite skills
                        set.Add(j);
                    }
                }
            }

            return set.Count;
        }
        //naive solution
        public int Solution2(int[] T, int[] A)
        {
            var doneCourses = new HashSet<int>();
            doneCourses.Add(0);

            foreach (var curCourse in A)
            {
                //add course to done
                doneCourses.Add(curCourse);
                var currentIndex = curCourse;
                while (T[currentIndex] != 0)
                {
                    doneCourses.Add(T[currentIndex]);
                    currentIndex = T[currentIndex];
                }
            }

            return doneCourses.Count;
        }
    }
}