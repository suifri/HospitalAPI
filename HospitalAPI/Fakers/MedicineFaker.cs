﻿using Bogus;
using HospitalAPI.Models;

namespace HospitalAPI.Fakers
{
    public class MedicineFaker : Faker<Medicine>
    {
        private IEnumerable<string> m_names = new string[] {    "Acetaminophen",
    "Amoxicillin",
    "Atorvastatin",
    "Azithromycin",
    "Ibuprofen",
    "Lisinopril",
    "Metformin",
    "Metoprolol",
    "Omeprazole",
    "Simvastatin",
    "Hydrochlorothiazide",
    "Amlodipine",
    "Gabapentin",
    "Warfarin",
    "Losartan",
    "Albuterol",
    "Levothyroxine",
    "Fluticasone",
    "Tamsulosin",
    "Citalopram",
    "Cephalexin",
    "Furosemide",
    "Tramadol",
    "Prednisone",
    "Metoprolol",
    "Diazepam",
    "Cyclobenzaprine",
    "Montelukast",
    "Sertraline",
    "Loratadine",
    "Cyclobenzaprine",
    "Rosuvastatin",
    "Fluoxetine",
    "Clonazepam",
    "Escitalopram",
    "Amphetamine",
    "Bupropion",
    "Hydrocodone",
    "Methylphenidate",
    "Methadone",
    "Duloxetine",
    "Pregabalin",
    "Lisdexamfetamine",
    "Venlafaxine",
    "Aripiprazole",
    "Carvedilol",
    "Varenicline",
    "Risperidone",
    "Quetiapine",
    "Buprenorphine",
    "Atomoxetine",
    "Olanzapine",
    "Atomoxetine",
    "Paliperidone",
    "Naloxone",
    "Aspirin",
    "Clopidogrel",
    "Esomeprazole",
    "Valsartan",
    "Ranitidine",
    "Pantoprazole",
    "Rivaroxaban",
    "Levofloxacin",
    "Tadalafil",
    "Sildenafil",
    "Tiotropium",
    "Voriconazole",
    "Amlodipine",
    "Pioglitazone",
    "Sitagliptin",
    "Dabigatran",
    "Eliquis",
    "Latanoprost",
    "Bimatoprost",
    "Ciprofloxacin",
    "Levetiracetam",
    "Memantine",
    "Duloxetine",
    "Venlafaxine",
    "Lamotrigine",
    "Zolpidem",
    "Rivastigmine",
    "Allopurinol",
    "Cetirizine",
    "Donepezil",
    "Mirtazapine",
    "Trazodone",
    "Sildenafil",
    "Tadalafil",
    "Finasteride",
    "Estradiol",
    "Oxybutynin",
    "Risedronate",
    "Alendronate",
    "Rosiglitazone",
    "Terbinafine",
    "Acyclovir",
    "Valacyclovir",
    "Oseltamivir",
    "Ceftriaxone",
    "Cefuroxime",
    "Cefdinir",
    "Cefpodoxime",
    "Cephalexin",
    "Clindamycin",
    "Azithromycin",
    "Amoxicillin",
    "Amoxicillin/clavulanate",
    "Levofloxacin",
    "Moxifloxacin",
    "Doxycycline",
    "Ciprofloxacin",
    "Metronidazole",
    "Fluconazole",
    "Ketoconazole",
    "Itraconazole",
    "Nystatin",
    "Clotrimazole",
    "Terbinafine",
    "Tolnaftate",
    "Fluticasone",
    "Triamcinolone",
    "Mometasone",
    "Budesonide",
    "Beclomethasone",
    "Dexamethasone",
    "Prednisone",
    "Prednisolone",
    "Hydrocortisone",
    "Ipratropium",
    "Tiotropium",
    "Fluticasone/salmeterol",
    "Budesonide/formoterol",
    "Mometasone/formoterol",
    "Fluticasone/vilanterol",
    "Albuterol",
    "Levalbuterol",
    "Ipratropium/albuterol",
    "Tiotropium/olodaterol",
    "Cromolyn",
    "Nedocromil",
    "Montelukast",
    "Zafirlukast",
    "Zileuton",
    "Omalizumab",
    "Dupilumab",
    "Mepolizumab",
    "Reslizumab",
    "Benralizumab",
    "Cetirizine",
    "Loratadine",
    "Fexofenadine",
    "Desloratadine",
    "Levocetirizine",
    "Olopatadine",
    "Ketotifen",
    "Cromolyn",
    "Nedocromil",
    "Fluticasone",
    "Fluticasone/salmeterol",
    "Fluticasone/vilanterol",
    "Budesonide/formoterol",
    "Mometasone/formoterol",
    "Albuterol",
    "Levalbuterol",
    "Ipratropium/albuterol",
    "Tiotropium/olodaterol",
    "Beclomethasone",
    "Ciclesonide",
    "Prednisone",
    "Prednisolone",
    "Hydrocortisone",
    "Methylprednisolone",
    "Dexamethasone",
    "Triamcinolone",
    "Betamethasone",
    "Fluticasone",
    "Mometasone",
    "Budesonide",
    "Clobetasol",
    "Desoximetasone",
    "Halobetasol",
    "Fluocinonide",
    "Amcinonide",
    "Halcinonide",
    "Hydrocortisone",
    "Prednicarbate",
    "Hydrocortisone butyrate",
    "Hydrocortisone valerate",
    "Hydrocortisone acetate",
    "Triamcinolone acetonide",
    "Betamethasone dipropionate",
    "Betamethasone valerate",
    "Mometasone furoate",
    "Desoximetasone",
    "Fluocinonide",
    "Clobetasol propionate",
    "Halobetasol propionate",
    "Ciprofloxacin",
    "Levofloxacin",
    "Ofloxacin",
    "Moxifloxacin",
    "Gatifloxacin",
    "Gemifloxacin",
    "Norfloxacin",
    "Tobramycin",
    "Gentamicin",
    "Polymyxin B",
    "Bacitracin",
    "Neomycin",
    "Ceftazidime",
    "Cefepime",
    "Cefotaxime",
    "Ceftriaxone",
    "Cefuroxime",
    "Cephalexin",
    "Azithromycin",
    "Clarithromycin",
    "Erythromycin",
    "Doxycycline",
    "Minocycline",
    "Tetracycline",
    "Clindamycin",
    "Metronidazole",
    "Vancomycin",
    "Linezolid",
    "Tigecycline",
    "Daptomycin",
    "Quinupristin/dalfopristin",
    "Nitrofurantoin",
    "Fosfomycin",
    "Trimethoprim/sulfamethoxazole",
    "Amphotericin B",
    "Fluconazole",
    "Ketoconazole",
    "Itraconazole",
    "Voriconazole",
    "Posaconazole",
    "Caspofungin",
    "Micafungin",
    "Anidulafungin",
    "Nystatin",
    "Terbinafine",
    "Griseofulvin",
    "Acyclovir",
    "Valacyclovir",
    "Famciclovir",
    "Penciclovir",
    "Ganciclovir",
    "Valganciclovir",
    "Cidofovir",
    "Foscarnet",
    "Docosanol",
    "Ribavirin",
    "Sofosbuvir",
    "Ledipasvir/sofosbuvir",
    "Daclatasvir",
    "Elbasvir/grazoprevir",
    "Ombitasvir/paritaprevir/ritonavir",
    "Velpatasvir/sofosbuvir",
    "Glecaprevir/pibrentasvir",
    "Emtricitabine/tenofovir",
    "Entecavir",
    "Telbivudine",
    "Adefovir",
    "Lamivudine",
    "Tenofovir",
    "Zidovudine",
    "Abacavir",
    "Dolutegravir",
    "Raltegravir",
    "Elvitegravir",
    "Etravirine",
    "Rilpivirine",
    "Efavirenz",
    "Nevirapine",
    "Atazanavir",
    "Darunavir",
    "Lopinavir/ritonavir",
    "Tipranavir",
    "Saquinavir",
    "Cobicistat",
    "Enfuvirtide",
    "Maraviroc",
    "Fosamprenavir",
    "Boceprevir",
    "Telaprevir",
    "Simeprevir",
    "Asunaprevir",
    "Daclatasvir",
    "Ledipasvir",
    "Ombitasvir",
    "Paritaprevir",
    "Ritonavir",
    "Sofosbuvir",
    "Velpatasvir",
    "Glecaprevir",
    "Pibrentasvir",
    "Emtricitabine",
    "Tenofovir",
    "Entecavir",
    "Telbivudine",
    "Adefovir",
    "Lamivudine",
    "Zidovudine",
    "Abacavir",
    "Dolutegravir",
    "Raltegravir",
    "Elvitegravir",
    "Etravirine",
    "Rilpivirine",
    "Efavirenz",
    "Nevirapine",
    "Atazanavir",
    "Darunavir",
    "Lopinavir",
    "Tipranavir",
    "Saquinavir",
    "Cobicistat",
    "Enfuvirtide",
    "Maraviroc",
    "Fosamprenavir",
    "Boceprevir",
    "Telaprevir",
    "Simeprevir",
    "Asunaprevir",
    "Daclatasvir",
    "Ledipasvir",
    "Ombitasvir",
    "Paritaprevir",
    "Ritonavir",
    "Sofosbuvir",
    "Velpatasvir",
    "Glecaprevir",
    "Pibrentasvir",
    "Emtricitabine",
    "Tenofovir",
    "Entecavir",
    "Telbivudine",
    "Adefovir",
    "Lamivudine",
    "Zidovudine",
    "Abacavir",
    "Dolutegravir",
    "Raltegravir",
    "Elvitegravir",
    "Etravirine",
    "Rilpivirine",
    "Efavirenz",
    "Nevirapine",
    "Atazanavir",
    "Darunavir",
    "Lopinavir",
    "Tipranavir",
    "Saquinavir",
    "Cobicistat",
    "Enfuvirtide",
    "Maraviroc",
    "Fosamprenavir",
    "Boceprevir",
    "Telaprevir",
    "Simeprevir",
    "Asunaprevir" };
        public MedicineFaker() 
        {
            RuleFor(m => m.Id, f => Guid.NewGuid());
            RuleFor(m => m.MName, f => m_names.ElementAt(f.Random.Number(0, m_names.Count() - 1)));// add medicine names
            RuleFor(m => m.MQuantity, f => f.Random.Number(1, 56));
            RuleFor(m => m.MCost, f => f.Random.Decimal(1, 1234));
            RuleFor(m => m.MAmount, f => f.Random.Number(10, 100));
            RuleFor(m => m.MDosage, f => f.Random.Number(5, 95));
        }
    }
}
