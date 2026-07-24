using System.Runtime.InteropServices;
using System;
namespace arrays;

public class arrays
{
    public static int Reversenum(int x)
    {
        long r =0;
        while(x!=0){
            int d=x%10;
            r=r*10+d;
            x/=10;
        }
        if(r<int.MinValue||r>int.MaxValue)return 0;
        return (int)r;
    }
    public static void Reverce(int[] nums, int l, int r)
        {
            while (l < r)
            {
                int temp = nums[l];
                nums[l] = nums[r];
                nums[r] = temp;
                l++;
                r--;
            }
        }

        public static int[] RotateArray(int[] nums, int k)
        {
            Reverce(nums, 0, nums.Length - 1);
            Reverce(nums, 0, k - 1);
            Reverce(nums, k, nums.Length - 1);
            return nums;
        }
        
        public static bool IsAnagram(string s, string t) {
            if(s.Length!=t.Length)return false;
            char []arr=s.ToCharArray();
            char []arr1=t.ToCharArray();
            Dictionary<char,int>map=new Dictionary<char,int>();
            for(int i =0;i<arr.Length;i++){
                map[s[i]]=map.GetValueOrDefault(s[i],0)+1;
            }
            for(int i =0;i<arr.Length;i++){
                if(map.ContainsKey(t[i])){
                    map[t[i]]=map.GetValueOrDefault(t[i],0)-1;
                }else{
                    return false ;
                }
            }
            foreach(var ele in map){
                if(ele.Value!=0){
                    return false;
                }
            }
            return true;
        }
        public static bool IsPalindrome(int x) {
            if(x<0)return false;
            List<int>list=new List<int>();
            while (x!=0){
                list.Add(x%10);
                x/=10;
            } 
            int l=0;
            int r =list.Count()-1;
            while(l<r){
                if(list[l]==list[r]){
                    Console.WriteLine(list[l]+"=="+list[r]);
                    l++;
                    r--;
                }
                else{
                    return false;
                }
            }
            return true;
        }
        
        
        
        
}