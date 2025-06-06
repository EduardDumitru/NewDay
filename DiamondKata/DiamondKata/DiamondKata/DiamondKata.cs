using System.Text;

namespace DiamondKata
{
    public static class DiamondKata
    {
        public static string CreateDiamond(char letter)
        {
            if ((letter >= 'a' && letter <= 'z' || letter >= 'A' && letter <= 'Z') is false)
            {
                throw new ArgumentException("Argument must be a letter", nameof(letter));
            }

            if (letter >= 'a' && letter <= 'z')
            {
                letter = (char)(letter - 32);
            }

            if (letter == 'A')
            {
                return "A";
            }

            var diamond = new StringBuilder();

            // Total number of rows in the diamond, calculated based on the distance of the input letter from 'A'.
            var size = (letter - 'A') * 2 + 1;

            // The middle index of the diamond, which is the row where the input letter will be placed.
            var middle = size / 2;

            // Tracks the current letter being processed.
            var currentLetter = 'A';
            for (var i = 0; i < size; i++)
            {
                // Calculates the number of underscores (_) needed for padding on each side of the letters.
                var underlines = Math.Abs(middle - i);
                diamond.Append('_', underlines);
                diamond.Append(currentLetter);
                if (currentLetter != 'A')
                {
                    diamond.Append('_', (size - 2 * underlines - 2));
                    diamond.Append(currentLetter);
                }
                diamond.Append('_', underlines);
                diamond.AppendLine();
                if (i < middle)
                {
                    currentLetter++;
                }
                else
                {
                    currentLetter--;
                }
            }

            return diamond.ToString().Trim();
        }

        public static int LengthOfLongestSubstring(string s)
        {
            if (s == null)
            {
                return 0;
            }
            int count = 0;
            int totalCount = 0;
            List<char> substring = new List<char>();
            for (int i = 0; i < s.Length; i++)
            {
                for (int j = i; j < s.Length; j++)
                {
                    if (substring.Contains(s[j]) == true)
                    {
                        substring.Clear();
                        count = 0;
                        break;
                    }

                    substring.Add(s[j]);
                    count++;
                    if (totalCount < count)
                    {
                        totalCount = count;
                    }
                }
            }
            return totalCount;
        }

        public static double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            // Ensure nums1 is the smaller array to minimize binary search iterations
            if (nums1.Length > nums2.Length)
            {
                return FindMedianSortedArrays(nums2, nums1);
            }

            int m = nums1.Length;
            int n = nums2.Length;
            int totalLeft = (m + n + 1) / 2;

            int left = 0, right = m;

            while (left <= right)
            {
                int partition1 = (left + right) / 2;
                int partition2 = totalLeft - partition1;

                int maxLeft1 = (partition1 == 0) ? int.MinValue : nums1[partition1 - 1];
                int minRight1 = (partition1 == m) ? int.MaxValue : nums1[partition1];

                int maxLeft2 = (partition2 == 0) ? int.MinValue : nums2[partition2 - 1];
                int minRight2 = (partition2 == n) ? int.MaxValue : nums2[partition2];

                if (maxLeft1 <= minRight2 && maxLeft2 <= minRight1)
                {
                    // Found the correct partition
                    if ((m + n) % 2 == 0)
                    {
                        return (Math.Max(maxLeft1, maxLeft2) + Math.Min(minRight1, minRight2)) / 2.0;
                    }
                    else
                    {
                        return Math.Max(maxLeft1, maxLeft2);
                    }
                }
                else if (maxLeft1 > minRight2)
                {
                    // Move partition1 to the left
                    right = partition1 - 1;
                }
                else
                {
                    // Move partition1 to the right
                    left = partition1 + 1;
                }
            }

            throw new ArgumentException("Input arrays are not sorted.");
        }

        public static string Convert(string s, int numRows)
        {
            if (numRows == 1 || s.Length <= numRows)
            {
                return s; // No zigzag needed if there's only one row or the string is too short
            }

            // Create a list of StringBuilder for each row
            var rows = new List<StringBuilder>();
            for (int i = 0; i < Math.Min(numRows, s.Length); i++)
            {
                rows.Add(new StringBuilder());
            }

            int currentRow = 0;
            bool goingDown = false;

            // Traverse the string and place characters in the appropriate row
            foreach (char c in s)
            {
                rows[currentRow].Append(c);

                // Change direction when reaching the top or bottom row
                if (currentRow == 0 || currentRow == numRows - 1)
                {
                    goingDown = !goingDown;
                }

                currentRow += goingDown ? 1 : -1;
            }

            // Combine all rows into a single string
            var result = new StringBuilder();
            foreach (var row in rows)
            {
                result.Append(row);
            }

            return result.ToString();
        }

        public static int Reverse(int x)
        {
            int reversedX = 0;

            while (x != 0)
            {
                int digit = x % 10; // Extract the last digit

                // Check for overflow before updating reversedX
                if (reversedX > (int.MaxValue / 10) || (reversedX == int.MaxValue / 10 && digit > 7))
                {
                    return 0; // Overflow occurred
                }
                if (reversedX < (int.MinValue / 10) || (reversedX == int.MinValue / 10 && digit < -8))
                {
                    return 0; // Underflow occurred
                }

                // Update reversedX
                reversedX = reversedX * 10 + digit;
                x = x / 10; // Remove the last digit from x
            }

            return reversedX;
        }

        public static string LongestCommonPrefix(string[] strs)
        {
            if (strs.Length == 0)
            {
                return string.Empty;
            }
            if (strs.Length == 1)
            {
                return strs[0];
            }
            string smallestString = strs[0];
            for (int i = 1; i < strs.Length; i++)
            {
                if (smallestString.Length > strs[i].Length)
                {
                    smallestString = strs[i];
                }
            }
            string prefix = string.Empty;
            bool prefixExists = false;
            var endIndex = 0;
            while (smallestString.Length > endIndex)
            {
                for (int i = 0; i < strs.Length; i++)
                {
                    for (int j = 0; j < smallestString.Length - endIndex; j++)
                    {
                        if (strs[i][j] != smallestString[j] || strs[i][smallestString.Length - endIndex - 1] != smallestString[smallestString.Length - endIndex - 1])
                        {
                            prefixExists = false;
                            break;
                        }
                        else
                        {
                            prefixExists = true;
                        }
                    }
                    if (prefixExists == false)
                    {
                        break;
                    }
                }

                if (prefixExists)
                {
                    if (endIndex == 0)
                    {
                        return smallestString;
                    }
                    return smallestString[..(smallestString.Length - endIndex)];
                }
                endIndex++;
            }
            return prefix;
        }

        public static IList<IList<int>> ThreeSum(int[] nums)
        {
            var result = new List<IList<int>>();

            // Sort the array
            Array.Sort(nums);

            for (int i = 0; i < nums.Length - 2; i++)
            {
                // Skip duplicates for the first number
                if (i > 0 && nums[i] == nums[i - 1])
                {
                    continue;
                }

                int left = i + 1;
                int right = nums.Length - 1;

                while (left < right)
                {
                    int sum = nums[i] + nums[left] + nums[right];

                    if (sum == 0)
                    {
                        // Add the triplet to the result
                        result.Add(new List<int> { nums[i], nums[left], nums[right] });

                        // Skip duplicates for the second and third numbers
                        while (left < right && nums[left] == nums[left + 1]) left++;
                        while (left < right && nums[right] == nums[right - 1]) right--;

                        left++;
                        right--;
                    }
                    else if (sum < 0)
                    {
                        left++; // Move the left pointer to increase the sum
                    }
                    else
                    {
                        right--; // Move the right pointer to decrease the sum
                    }
                }
            }

            return result;
        }

        public static int ThreeSumClosest(int[] nums, int target)
        {
            Array.Sort(nums);
            int closestSum = nums[0] + nums[1] + nums[2];

            for (int i = 0; i < nums.Length - 2; i++)
            {
                int left = i + 1;
                int right = nums.Length - 1;

                while (left < right)
                {
                    int currentSum = nums[i] + nums[left] + nums[right];

                    // If this sum is closer to target, update closestSum
                    if (Math.Abs(currentSum - target) < Math.Abs(closestSum - target))
                    {
                        closestSum = currentSum;
                    }

                    // Move pointers based on comparison
                    if (currentSum < target)
                    {
                        left++;
                    }
                    else if (currentSum > target)
                    {
                        right--;
                    }
                    else
                    {
                        // Exact match found
                        return currentSum;
                    }
                }
            }

            return closestSum;
        }

        public static IList<string> LetterCombinations(string digits)
        {
            if (string.IsNullOrEmpty(digits))
                return new List<string>();

            string[] mapping = new string[]
            {
                "",     // 0
                "",     // 1
                "abc",  // 2
                "def",  // 3
                "ghi",  // 4
                "jkl",  // 5
                "mno",  // 6
                "pqrs", // 7
                "tuv",  // 8
                "wxyz"  // 9
            };

            var result = new List<string> { "" };

            foreach (char digit in digits)
            {
                var temp = new List<string>();
                string letters = mapping[digit - '0'];
                foreach (var combination in result)
                {
                    foreach (var letter in letters)
                    {
                        temp.Add(combination + letter);
                    }
                }
                result = temp;
            }

            return result;
        }

        public static IList<IList<int>> FourSum(int[] nums, int target)
        {
            var result = new List<IList<int>>();
            if (nums.Length < 4) return result;

            Array.Sort(nums);

            for (int i = 0; i < nums.Length - 3; i++)
            {
                if (i > 0 && nums[i] == nums[i - 1]) continue; // Skip duplicates for i

                for (int j = i + 1; j < nums.Length - 2; j++)
                {
                    if (j > i + 1 && nums[j] == nums[j - 1]) continue; // Skip duplicates for j

                    int left = j + 1;
                    int right = nums.Length - 1;

                    while (left < right)
                    {
                        // Use long to avoid integer overflow
                        long sum = (long)nums[i] + nums[j] + nums[left] + nums[right];

                        if (sum == target)
                        {
                            result.Add(new List<int> { nums[i], nums[j], nums[left], nums[right] });

                            // Skip duplicates for left and right
                            while (left < right && nums[left] == nums[left + 1]) left++;
                            while (left < right && nums[right] == nums[right - 1]) right--;

                            left++;
                            right--;
                        }
                        else if (sum < target)
                        {
                            left++;
                        }
                        else
                        {
                            right--;
                        }
                    }
                }
            }

            return result;
        }

        public class ListNode
        {
            public int val;
            public ListNode next;

            public ListNode(int val = 0, ListNode next = null)
            {
                this.val = val;
                this.next = next;
            }
        }

        public static ListNode RemoveNthFromEnd(ListNode head, int n)
        {
            // Step 1: Create a dummy node
            var dummy = new ListNode(0, head);
            var fast = dummy;
            var slow = dummy;

            // Step 2: Move fast pointer n+1 steps ahead
            for (int i = 0; i <= n; i++)
            {
                fast = fast.next;
            }

            // Step 3: Move both pointers until fast reaches the end
            while (fast != null)
            {
                fast = fast.next;
                slow = slow.next;
            }

            // Step 4: Remove the nth node from the end
            slow.next = slow.next.next;

            // Return the new head
            return dummy.next;
        }
    }
}