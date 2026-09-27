# Assignment 07: การเรียนรู้ Searching Algorithms สำหรับ Game Development

## 🎯 จุดประสงค์การเรียนรู้

- เรียนรู้การใช้งาน Searching Algorithms พื้นฐาน (Sequential Search, Binary Search)
- เข้าใจการค้นหาข้อมูลใน array 1 มิติและ 2 มิติ
- นำ Searching Algorithms มาใช้ในการแก้ปัญหาในเกม เช่น การหาตำแหน่งของไอเท็ม, หาค่าสูงสุด-ต่ำสุด
- วิเคราะห์การค้นหาในข้อมูลที่เรียงลำดับและไม่เรียงลำดับ
- เขียน code ที่มีประสิทธิภาพในการจัดการข้อมูลแบบค้นหา

## 📚 โครงสร้างของ Assignment

- **Lecture Methods (3 methods)** - การ implement ฝึกหัด Searching Algorithms พื้นฐาน พร้อมกันในห้องเรียน
- **Assignment Methods (3 methods)** - การประยุกต์ใช้ Searching Algorithms ในสถานการณ์เกม
- **Extra Methods (1 method)** - การแก้ปัญหาขั้นสูงที่เกี่ยวข้องกับการค้นหา

เมธอดทั้งหมดคืนผลลัพธ์ตามชนิดข้อมูลใน Method Signature โดยตรง ไม่ต้องใช้ `Debug.Log` เพื่อส่งผลลัพธ์

---

## 🧠 ความรู้พื้นฐานที่ควรทราบ

### Searching Algorithms คืออะไร?
Searching Algorithm คือขั้นตอนการค้นหาข้อมูลในโครงสร้างข้อมูล เช่น array

### ในเกมใช้ Searching ทำอะไรบ้าง?
- **หาตำแหน่งไอเท็ม**: ค้นหาว่าไอเท็มอยู่ที่ไหนใน inventory
- **หาค่าสูงสุด/ต่ำสุด**: หา damage สูงสุด หรือ HP ต่ำสุด
- **ค้นหาใน leaderboard**: หาตำแหน่งของผู้เล่นในอันดับ Leaderboard

---

หมายเหตุ: Lecture Methods ไม่มี parameter เพราะใช้ array และ target ที่กำหนดไว้ภายในแต่ละเมธอด ตัวอย่าง input ในเอกสารใช้ประกอบความเข้าใจ หากต้องการลอง input อื่น ให้แก้ค่าภายในเมธอดชั่วคราว ไม่สามารถส่งค่าเข้าเมธอดผ่าน parameter ได้

## Lecture Methods

### 1. LCT01_SequentialSearch1DArray

**วัตถุประสงค์:** เรียนรู้การทำงานของ Sequential Search ใน array 1 มิติ

**หลักการทำงานของ Sequential Search:**
1. เริ่มจาก index 0
2. เปรียบเทียบแต่ละ element กับ target
3. ถ้าพบ ให้คืน index นั้น
4. ถ้าไม่พบจนจบ array ให้คืน -1

**Method Signature:**
```csharp
int LCT01_SequentialSearch1DArray()
```

**Logic ที่ต้อง implement:**
- ใช้ loop เดินผ่าน array
- เปรียบเทียบ array[i] == target
- return index ที่พบ หรือ -1 ถ้าไม่พบ

**Hint:** เริ่ม loop ที่ index `0` และหยุดทันทีเมื่อพบ target เพราะต้องการ index แรก หากวนครบแล้วยังไม่พบ ให้คืน `-1`

**Test Cases:**
1. **Input:** array = [34, 21, 56, 12, 78, 90, 11, 23], target = 90
   **Expected Return Value:**
   ```
   5
   ```

2. **Input:** array = [1, 2, 3, 4, 5], target = 6
   **Expected Return Value:**
   ```
   -1
   ```

### 2. LCT02_SequentialSearch2DArray

**วัตถุประสงค์:** เรียนรู้การทำงานของ Sequential Search ใน array 2 มิติ

**หลักการทำงานของ Sequential Search ใน 2D:**
1. ใช้ nested loop เดินผ่านทุก row และ column
2. เปรียบเทียบ array[i,j] == target
3. ถ้าพบ ให้คืน (i,j)
4. ถ้าไม่พบ ให้คืน (-1,-1)

**Method Signature:**
```csharp
int[] LCT02_SequentialSearch2DArray()
```

**Logic ที่ต้อง implement:**
- ใช้ nested loop: outer for rows, inner for columns
- เปรียบเทียบ array[i,j] == target
- return `[row, col]` หรือ `[-1, -1]`

**Hint:** เมื่อพบค่าให้คืน `new int[] { row, col }` ทันที หากวนครบทุกช่องแล้วยังไม่พบ ให้คืน `new int[] { -1, -1 }`

**Test Cases:**
1. **Input:** array = [[34,21,56],[12,78,90],[11,23,45]], target = 23
   **Expected Return Value:**
   ```
   [2, 1]
   ```

2. **Input:** array = [[1,2],[3,4]], target = 5
   **Expected Return Value:**
   ```
   [-1, -1]
   ```

### 3. LCT03_BinarySearch

**วัตถุประสงค์:** เรียนรู้การทำงานของ Binary Search ใน array ที่เรียงลำดับ

**หลักการทำงานของ Binary Search:**
1. array ต้องเรียงลำดับแล้ว
2. หาค่า mid = (left + right) / 2
3. ถ้า array[mid] == target, พบแล้ว
4. ถ้า array[mid] < target, ค้นหาด้านขวา (left = mid + 1)
5. ถ้า array[mid] > target, ค้นหาด้านซ้าย (right = mid - 1)
6. ทำซ้ำจน left > right

**Method Signature:**
```csharp
int LCT03_BinarySearch()
```

**Logic ที่ต้อง implement:**
- ใช้ while loop: left <= right
- คำนวณ mid
- เปรียบเทียบและปรับ left/right
- return index หรือ -1

**Hint:** เมื่อ `array[mid]` ไม่ตรงกับ target ให้ตัดครึ่งช่วงค้นหาทุกครั้ง เลื่อน `left` หรือ `right` ข้ามตำแหน่ง `mid` ด้วย เพื่อให้ loop เดินหน้าจนจบ

**Test Cases:**
1. **Input:** array = [11,12,21,23,34,45,56,78,90], target = 23
   **Expected Return Value:**
   ```
   3
   ```

2. **Input:** array = [1,2,3,4,5], target = 6
   **Expected Return Value:**
   ```
   -1
   ```

---

## Assignment Methods

### AS01_FindFirstAndLastElementOfArray

**วัตถุประสงค์:** หาตำแหน่งแรกและตำแหน่งสุดท้ายของค่าใน array

**ตัวอย่างการใช้งานในเกม:** หาตำแหน่งแรกและสุดท้ายของไอเท็มใน inventory

**Method Signature:**
```csharp
int[] AS01_FindFirstAndLastElementOfArray(int[] array, int target)
```

**Logic ที่ต้อง implement:**
- วน loop หา first และ last
- ถ้าไม่พบ ให้ return `[-1]`
- ถ้าพบ ให้ return `[first, last]`

**Hint:** กำหนด `first` และ `last` เป็น `-1` ก่อนเริ่มค้นหา เมื่อพบ target ครั้งแรกให้บันทึก `first` และอัปเดต `last` ทุกครั้งที่พบ จากนั้นคืน array ที่มีสองค่านี้

**Test Cases:**
1. **Input:** array = [1, 2, 2, 2, 3], target = 2
   **Expected Return Value:**
   ```
   [1, 3]
   ```

2. **Input:** array = [1, 2, 3, 4, 5], target = 6
   **Expected Return Value:**
   ```
   [-1]
   ```

3. **Input:** array = [5, 5, 5, 5, 5], target = 5
   **Expected Return Value:**
   ```
   [0, 4]
   ```

### AS02_FindMaxLessThan

**วัตถุประสงค์:** หาค่าที่มากที่สุดที่น้อยกว่าค่าที่กำหนด

**ตัวอย่างการใช้งานในเกม:** หาไอเท็มที่มี level สูงที่สุดซึ่งยังต่ำกว่า level ที่กำหนด

**Method Signature:**
```csharp
int AS02_FindMaxLessThan(int[] array, int target)
```

**Logic ที่ต้อง implement:**
- ตรวจสมาชิกใน array ได้เลย ไม่จำเป็นต้องเรียงลำดับก่อน
- หาค่าที่มากที่สุดที่ < target
- ถ้าไม่มี ให้ return -1

**Hint:** เก็บค่าที่มากที่สุดที่ยังน้อยกว่า target ไว้ในตัวแปร ถ้าไม่พบค่าใดเลยจึงคืน `-1` เงื่อนไขคือ `< target` ไม่ใช่ `<= target` ใช้ตัวแปร `found` แยกสถานะการพบค่า เพื่อให้รองรับข้อมูลที่เป็นจำนวนติดลบได้ถูกต้อง

**Test Cases:**
1. **Input:** array = [4, 2, 10, 9, 8, 11], target = 9
**Expected Return Value:**
   ```
   8
   ```

2. **Input:** array = [4, 2, 10, 9, 8, 11], target = 2
**Expected Return Value:**
   ```
   -1
   ```

3. **Input:** array = [1, 2, 3, 5, 6], target = 5
**Expected Return Value:**
   ```
   3
   ```

4. **Input:** array = [15, 5, 20, 40, 30], target = 5
**Expected Return Value:**
   ```
   -1
   ```

### AS03_FindRange

**วัตถุประสงค์:** หาค่าที่อยู่ในช่วง min-max

**ตัวอย่างการใช้งานในเกม:** หาไอเท็มที่มี level อยู่ในช่วงที่ player เลือก

**Method Signature:**
```csharp
int[] AS03_FindRange(int[] array, int min, int max)
```

**Logic ที่ต้อง implement:**
- ตรวจสมาชิกใน array ทีละตัว
- return ค่าในช่วง `min <= value <= max` เป็น array โดยคงลำดับเดิมของ array ต้นฉบับ
- ถ้าไม่มีค่าในช่วง ให้ return array ว่าง `[]`

**Hint:** ใช้ `List<int>` เก็บค่าที่ผ่านเงื่อนไข แล้วคืน `result.ToArray()` เมื่อวนครบ ช่วงนี้รวมค่า `min` และ `max` ด้วย ถ้า `min > max` ผลลัพธ์ควรเป็น array ว่าง

**Test Cases:**
1. **Input:** array = [1, 3, 5, 7, 9], min = 4, max = 8
   **Expected Return Value:**
   ```
   [5, 7]
   ```

2. **Input:** array = [1, 2, 3, 4, 5], min = 6, max = 10
   **Expected Return Value:**
   ```
   []
   ```

3. **Input:** array = [10, 20, 30, 40, 50], min = 10, max = 50
   **Expected Return Value:**
   ```
   [10, 20, 30, 40, 50]
   ```

---

## Extra Methods

### EX01_FindTargetEnemies

**วัตถุประสงค์:** หาศัตรูที่สามารถทำลายได้ด้วย mana ที่มี โดยให้มีจำนวนของศัตรูที่ถูกทำลายมากที่สุด

**ตัวอย่างการใช้งานในเกม:** เลือกกลุ่มศัตรูที่สามารถโจมตีได้ด้วยสกิลที่มี mana จำกัด

**Method Signature:**
```csharp
int[] EX01_FindTargetEnemies(int[] enemyHPs, int mana)
```

**Logic ที่ต้อง implement:**
- พิจารณา HP จากน้อยไปมาก
- เลือกศัตรูที่มี hp รวม <= mana, ให้ได้จำนวนมากที่สุด (greedy: เลือก hp น้อยก่อน)
- return hp ของศัตรูที่เลือกเป็น array

**Hint:** เรียงสำเนาของข้อมูลจากน้อยไปมาก แล้วสะสม HP ทีละตัว เลือกตัวถัดไปเมื่อยอดรวมยังไม่เกิน mana และหยุดเมื่อเลือกตัวถัดไปไม่ได้ คืนเฉพาะ HP ที่เลือกโดยไม่เปลี่ยน array ต้นฉบับ

**Test Cases:**
1. **Input:** enemyHPs = [2, 3, 7, 8, 10], mana = 15
   **Expected Return Value:**
   ```
   [2, 3, 7]
   ```

2. **Input:** enemyHPs = [2, 3, 7, 8, 10], mana = 3
   **Expected Return Value:**
   ```
   [2]
   ```

3. **Input:** enemyHPs = [2, 3, 7, 8, 10], mana = 6
   **Expected Return Value:**
   ```
   [2, 3]
   ```

---

## 💡 เทคนิคการเขียนโปรแกรม

### 1. การเปรียบเทียบ Searching Algorithms

| Algorithm | ความเร็ว | ข้อกำหนด | Big-O |
|-----------|---------|----------|-------|
| Sequential Search | ช้า | ไม่ต้องเรียงลำดับ | O(n) |
| Binary Search | เร็ว | ต้องเรียงลำดับ | O(log n) |

### 2. การเลือกใช้ใน Game Development

- **ข้อมูลไม่เรียงลำดับ**: ใช้ Sequential Search
- **ข้อมูลเรียงลำดับแล้ว**: ใช้ Binary Search สำหรับความเร็ว
- **ต้องการหาตำแหน่งทั้งหมด**: ใช้ Sequential Search แม้เรียงแล้ว

### 3. การจัดการ Edge Cases

- **Array ว่าง**: ตรวจสอบ array.Length == 0
- **ไม่พบค่า**: คืน -1 หรือ array ว่าง `[]` ตามชนิดผลลัพธ์ของเมธอด
- **ค่าซ้ำ**: จัดการตาม requirement (first/last, max less than, etc.)

---

## 🚀 การประยุกต์ใช้ในเกม

### 1. RPG Game
- ค้นหาไอเท็มใน inventory หรือ shop
- หา skill หรือ item ที่แรงที่สุดที่ player สามารถใช้ได้
- ตรวจสอบเงื่อนไขการ unlock หรือ achievement

### 2. Strategy Game
- หาตำแหน่ง unit หรือ building ใน map
- ค้นหา resource หรือ enemy ที่อยู่ใน range
- วิเคราะห์ stat ของ unit ใน army

### 3. Puzzle Game
- หา piece หรือ tile ที่ตรงกับเงื่อนไข
- ค้นหา path หรือ solution ที่สั้นที่สุด
- ตรวจสอบ pattern หรือ sequence ใน puzzle
