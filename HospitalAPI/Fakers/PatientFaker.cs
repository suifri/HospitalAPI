using Bogus;
using HospitalAPI.Constants;
using HospitalAPI.Models;

namespace HospitalAPI.Fakers
{
    public class PatientFaker : Faker<Patient>
    {
        private string[] Conditions = new string[] { PatientConditions.Stable, PatientConditions.Improving, PatientConditions.Deteriorating,
            PatientConditions.Rehabilitation, PatientConditions.Chronic, PatientConditions.Critical, PatientConditions.PostOperative};

        List<string> diseases = new List<string>
{
    "AIDS",
    "Acne",
    "Allergy",
    "Alzheimer's Disease",
    "Anemia",
    "Anorexia Nervosa",
    "Appendicitis",
    "Arthritis",
    "Asthma",
    "Atherosclerosis",
    "Autism",
    "Back Pain",
    "Bipolar Disorder",
    "Bladder Cancer",
    "Blood Clot",
    "Bone Cancer",
    "Breast Cancer",
    "Bronchitis",
    "Celiac Disease",
    "Cervical Cancer",
    "Chickenpox",
    "Chlamydia",
    "Chronic Fatigue Syndrome",
    "Chronic Obstructive Pulmonary Disease (COPD)",
    "Colon Cancer",
    "Common Cold",
    "Congestive Heart Failure",
    "Crohn's Disease",
    "Cystic Fibrosis",
    "Dementia",
    "Depression",
    "Diabetes",
    "Diarrhea",
    "Diverticulitis",
    "Down Syndrome",
    "Eating Disorders",
    "Endometriosis",
    "Epilepsy",
    "Erectile Dysfunction",
    "Fibromyalgia",
    "Gallstones",
    "Gastritis",
    "Gastroesophageal Reflux Disease (GERD)",
    "Gastrointestinal Bleeding",
    "Glaucoma",
    "Gonorrhea",
    "Gout",
    "Graves' Disease",
    "Gum Disease",
    "Hashimoto's Disease",
    "Heart Attack",
    "Hemorrhoids",
    "Hepatitis",
    "Hernia",
    "HIV",
    "HPV (Human Papillomavirus)",
    "Hypertension",
    "Hypothyroidism",
    "Inflammatory Bowel Disease (IBD)",
    "Influenza",
    "Insomnia",
    "Interstitial Cystitis",
    "Irritable Bowel Syndrome (IBS)",
    "Kidney Cancer",
    "Kidney Stones",
    "Leukemia",
    "Liver Cancer",
    "Lung Cancer",
    "Lupus",
    "Lyme Disease",
    "Macular Degeneration",
    "Malaria",
    "Melanoma",
    "Menopause",
    "Migraine",
    "Multiple Sclerosis",
    "Muscular Dystrophy",
    "Narcolepsy",
    "Nasal Polyps",
    "Obesity",
    "Obsessive-Compulsive Disorder (OCD)",
    "Osteoarthritis",
    "Osteoporosis",
    "Ovarian Cancer",
    "Overactive Bladder",
    "Pancreatic Cancer",
    "Parkinson's Disease",
    "Pelvic Inflammatory Disease (PID)",
    "Peptic Ulcer Disease",
    "Peripheral Artery Disease (PAD)",
    "Pneumonia",
    "Polycystic Ovary Syndrome (PCOS)",
    "Post-Traumatic Stress Disorder (PTSD)",
    "Preterm Birth",
    "Prostate Cancer",
    "Psoriasis",
    "Rheumatoid Arthritis",
    "Rosacea",
    "Rotator Cuff Injury",
    "Schizophrenia",
    "Scoliosis",
    "Sexually Transmitted Infections (STIs)",
    "Shingles",
    "Sinusitis",
    "Skin Cancer",
    "Sleep Apnea",
    "Sleep Disorders",
    "Smallpox",
    "Sore Throat",
    "Stomach Cancer",
    "Strep Throat",
    "Stroke",
    "Testicular Cancer",
    "Thyroid Cancer",
    "Tinnitus",
    "Tonsillitis",
    "Tooth Decay",
    "Tuberculosis",
    "Ulcerative Colitis",
    "Urinary Tract Infection (UTI)",
    "Uterine Cancer",
    "Vaginal Cancer",
    "Varicose Veins",
    "Vertigo",
    "West Nile Virus",
    "Whooping Cough",
    "Yellow Fever",
    "Zika Virus"
};

        public PatientFaker() 
        {
            RuleFor(p => p.Id, Guid.NewGuid());
            RuleFor(p => p.PatientFName, f => f.Person.FirstName);
            RuleFor(p => p.PatientLName, f => f.Person.LastName);
            RuleFor(p => p.Phone, f => f.Phone.PhoneNumber());
            RuleFor(p => p.BloodType, f => PatientConditions.BloodTypes.ElementAt(f.Random.Number(0, PatientConditions.BloodTypes.Count() - 1)));
            RuleFor(p => p.Rhesus, f => f.Random.Bool());
            RuleFor(p => p.Email, f => f.Person.Email);
            RuleFor(p => p.Gender, f => f.Person.Gender.ToString());
            RuleFor(p => p.Condition, f => Conditions[f.Random.Int(0, Conditions.Length - 1)]);
            RuleFor(p => p.AdmissionDate, f=> f.Date.Past());
            RuleFor(p => p.DischargeTime, f => f.Date.Recent());
            RuleFor(p => p.Diagnosis, f => f.PickRandom(diseases));
        }
    }
}
