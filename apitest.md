Yesss 🔥 perfect Akshat — Health API working means:

✅ Controllers working
✅ Postman connected
✅ Backend running properly

Now let’s test the real APIs with sample data.

---

# ✅ 1. Test Contact Form API

### Endpoint

**Method:** POST
**URL:**

```
http://localhost:5134/api/contact
```

---

## Postman Setup

### Step A: Go to Body

* Click **Body**
* Select **raw**
* Choose **JSON**

---

## Sample JSON Data

Paste this:

```json
{
  "name": "Akshat Verma",
  "email": "akshatverma@gmail.com",
  "phone": "9999999999",
  "subject": "Studio Contact Test",
  "message": "Hello, this is a test message from Postman for the contact form API."
}
```

---

## Expected Response

```json
{
  "success": true
}
```

That means:

✅ Data saved in SQL Server
✅ Email will send (if Gmail configured)

---

---

# ✅ 2. Test Apply Form API

### Endpoint

**Method:** POST
**URL:**

```
http://localhost:5134/api/apply
```

---

## Body → raw → JSON

Paste:

```json
{
  "fullName": "Akshat Verma",
  "email": "akshatapply@gmail.com",
  "phone": "8888888888",
  "productionCompany": "Akshat Films Pvt Ltd",
  "projectTitle": "Brand Commercial Shoot",
  "projectType": "Advertisement",
  "preferredLocation": "Mumbai",
  "estimatedBudget": "5-10 Lakhs",
  "additionalNotes": "We need full production support including crew and equipment."
}
```

---

## Expected Response

```json
{
  "success": true
}
```

That means:

✅ Application stored in DB
✅ Admin notified via email

---

---

# ✅ 3. Check Database Data (Optional)

Run SQL query:

### Contact Messages

```sql
SELECT * FROM ContactMessages;
```

### Applications

```sql
SELECT * FROM ProjectApplications;
```

You will see your Postman test rows.

---

---

# ❌ If You Get Error

### 400 Bad Request

Means required fields missing.

### 500 Internal Server Error

Usually DB connection issue or migrations not applied.

Tell me the exact error response and I’ll fix instantly.

---

# 🚀 Next Upgrade

Do you want these APIs also:

✅ GET all contact messages
✅ GET all applications
✅ Admin Dashboard API
✅ Resume Upload in Apply Form

Just reply: **Yes add admin APIs**
