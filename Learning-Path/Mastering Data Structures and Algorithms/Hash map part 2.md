
---

## II. Why "Conflicts" (Collisions) are MANDATORY 💥

A  **conflict** , or  **collision** , occurs when two or more different keys, after being processed by the hash function and the modulo operation, end up pointing to the same single  **bucket** . Collisions are an almost unavoidable phenomenon in general-purpose hash maps.

### 1. The Pigeonhole Principle - The Root Cause of Collisions

This principle is key to understanding why collisions are inevitable. It simply states: "If you have more 'pigeons' than available 'pigeonholes,' then at least one pigeonhole must contain more than one pigeon."

What are "Pigeons" in a Hash Map?

This refers not just to the number of keys you are actually storing at a given moment, but more importantly, to the space of all POSSIBLE keys (potential keys).

* **Detailed Examples of "Pigeons" (Potential Keys):**
  * If your key is an uppercase English letter (A-Z): there are  **26 potential keys** .
  * If your key is a string of 2 uppercase English letters (AA, AB, ..., ZZ): there are **26**∗**26**=**676 potential keys**.
  * If your key is a 16-bit integer: there are **2**16**=**65,536 potential keys.
  * If your key is any character string up to 255 characters long, using the ASCII character set (128 characters): the number of potential keys is **12**8**1**+**12**8**2**+**...**+**12**8**255** – an  **ENORMOUS** , practically infinite number.

What are "Pigeonholes" in a Hash Map?

This is simply the finite number of buckets that your hash map has.

* **Detailed Examples of "Pigeonholes" (Buckets):**
  * A hash map might be initialized with  **16 buckets** .
  * After resizing, it might have  **32 buckets** , then  **64 buckets** , and so on.

No matter how much the number of buckets increases, it is always a **finite number** and usually **MUCH, MUCH smaller** than the space of potential keys.

Applying the Principle:

Because the number of "pigeons" (potential keys) almost always vastly exceeds the number of "pigeonholes" (available buckets), it is mathematically inevitable that multiple different keys will eventually have to "crowd" into the same bucket.

### 2. The Hash Function and Modulo Operation as "Pigeon Allocators"

The `hash_function(key)` attempts to generate a well-distributed hash code. The **modulo operation** `hash_code % numberOfBuckets` then "squeezes" this hash code into one of the `numberOfBuckets` available slots. It is this "squeezing" step, from a large space of numbers (hash codes) to a smaller space (bucket indices), where collisions become evident.

### 3. Detailed Specific Examples of the Inevitability of Collisions

Case 1: The number of actual keys exceeds the number of buckets (most obvious scenario):

Assume your hash map has 3 buckets (indexed 0, 1, 2).

You want to add the following keys (let's assume a simple hash function hash(x) = first_ASCII_value_of_x):

* **a. Add key "Apple":**
  * `hash("Apple")` = 65 (ASCII for 'A').
  * `index = 65 % 3 = 2`. Bucket 2 stores "Apple".
* **b. Add key "Banana":**
  * `hash("Banana")` = 66 (ASCII for 'B').
  * `index = 66 % 3 = 0`. Bucket 0 stores "Banana".
* **c. Add key "Cherry":**
  * `hash("Cherry")` = 67 (ASCII for 'C').
  * `index = 67 % 3 = 1`. Bucket 1 stores "Cherry".
  * **At this point:** `buckets = [ "Banana", "Cherry", "Apple" ]`. All buckets are used.
* **d. Add key "Date":**
  * `hash("Date")` = 68 (ASCII for 'D').
  * `index = 68 % 3 = 2`.
  * **Problem:** Bucket 2 already contains "Apple". Now "Date" also wants to go into bucket 2. This is a **MANDATORY COLLISION** because there are no empty buckets left, and the number of actual keys (4) has exceeded the number of buckets (3).

Case 2: Collisions occur even when the number of actual keys is less than the number of buckets (due to the nature of hash functions and modulo):

Assume your hash map has 10 buckets (0-9).

You only want to add 2 keys:

* **a. Add key "cat":**
  * Let's say `hash("cat")` (after some complex hashing algorithm) results in a hash code of 12347.
  * `index = 12347 % 10 = 7`. Bucket 7 stores "cat".
* **b. Add key "dog":**
  * Let's say `hash("dog")` (after a different complex hashing algorithm) unfortunately results in a hash code of 78967.
  * `index = 78967 % 10 = 7`.
  * **Problem:** Bucket 7 already contains "cat". Now "dog" also wants to go into bucket 7. This is a  **COLLISION** , even though we only have 2 keys and 10 buckets.
  * This happens because a general-purpose hash function cannot guarantee perfect uniqueness for all inputs when mapping them to a limited number of buckets via the modulo operation. Two completely different keys can coincidentally have hash codes that, when divided by `numberOfBuckets`, yield the same remainder.

---

### Conclusion on the Necessity of Collisions (and handling them):

**Collisions are an inherent, unavoidable characteristic of general-purpose hash maps** due to the limitations of a finite number of buckets compared to the vast potential key space, and the many-to-one mapping nature of the hash function + modulo mechanism.

Instead of trying to eliminate collisions entirely (which is impossible in the general case), hash map designers focus on:

* **Using good hash functions:** To minimize the frequency of collisions and distribute them as evenly as possible.
* **Implementing effective collision resolution strategies:** Such as **Separate Chaining** (each bucket is a linked list) or **Open Addressing** (probing for the next empty bucket).

Therefore, the fact that a hash map must be able to have collisions means it must also have a strategy in place to resolve those collisions.
